#include <TM4C123Gh6PM.h>

void initialize_PWM();
void togglePWM();

void initializePWMTogglingButton();

void initializeUART();

void receiveData();

signed char idx = -1;//determine the current byte... we will receive 5 bytes at a time
unsigned int signalDuration = 0;
unsigned char DutyRatio = 0;

int main()
{
	initialize_PWM();
	
	initializePWMTogglingButton();
	
	initializeUART();

	while(1)
	{
		receiveData();
	}
	
	return 0;
}

void initialize_PWM()
{
	SYSCTL->RCGCGPIO |= 0x08; 
	GPIOD->DIR |= 0x04; 
	GPIOD->AFSEL |= 0x04; 
	GPIOD->PCTL &= ~0x0F00; 
	GPIOD->PCTL |= 0x0700; 
	GPIOD->DEN |= 0x04;
 
	SYSCTL->RCGCWTIMER |= 0x08; 
	WTIMER3->CTL = 0x00; 
	WTIMER3->CFG = 0x04; 
	WTIMER3->TAILR = 1000000;//default
	WTIMER3->TAMATCHR = WTIMER3->TAILR * (1.f - 0.75f);//default
	WTIMER3->TAMR = 0b1010; 
	WTIMER3->CTL = 0x01; 
}

void togglePWM()
{
	GPIOD->DEN ^= 0x04;
}

void initializePWMTogglingButton()
{
	SYSCTL->RCGCGPIO |= 0x01;
	GPIOA->DIR &= ~0x04;
	GPIOA->PDR |= 0x04;
	GPIOA->IS &= ~0x04;
	GPIOA->IEV |= 0x04;
	GPIOA->ICR |= 0x04;
	GPIOA->IM |= 0x04;
	GPIOA->DEN |= 0x04;
	
	NVIC_EnableIRQ(GPIOA_IRQn);
	__enable_irq();
	
	//The SysTick is used here as a cheap debouncer
	//The GPIOA_Handler() will not get executed if the SysTick is still counting
	//In this way we read the button once, and then wait for SysTick to finish counting to avoid bouncnig
	SysTick->LOAD = 4000000;//read one input at every 4000000/4MHz seconds = 1s 
	SysTick->CTRL = 1;
}

void GPIOA_Handler()
{
	GPIOA->ICR |= 0x04;
	int forcing = GPIOA->ICR;
	
	if (!(SysTick->CTRL & 0x10000))//simple debouncer
		return;
	
	togglePWM();
}

void initializeUART()
{ 	
	SYSCTL->RCGCUART |= 1;
	
	SYSCTL->RCGCGPIO |= 1;
	
	UART0->CTL = 0;
	UART0->IBRD = 325;// 50000000/(16 x 9600) = int(325.521) = 325
	UART0->FBRD = 33; //  int(0.521 x 64 + 0.5) = int(33.844) = 33
	UART0->CC = 0;
	UART0->LCRH = 0x60;//8-bit, no parity, 1-stop bit, no FIFO 
	UART0->CTL = 0x201;//enable UART0 and use Rx

	GPIOA->DEN |= 0x01;
	GPIOA->AFSEL |= 0x01;
	GPIOA->PCTL &= ~0x0000000F;
	GPIOA->PCTL |= 0x00000001;
} 

//This funciton is respnsible of reading the upcoming data and changnig the PWM settings
void receiveData()
{
	if(!(UART0->FR & 0x10))
		{
			switch(++idx)
			{
				case 0:
					DutyRatio = UART0->DR;
					break;
				case 1:
					signalDuration &= ~0xFF;
					signalDuration |= UART0->DR;
					break;
				case 2:
					signalDuration &= ~0xFF00;
					signalDuration |= UART0->DR << 8;
					break;
				case 3:
					signalDuration &= ~0xFF0000;
					signalDuration |= UART0->DR << 16;
					break;
				case 4:
					signalDuration &= ~0xFF000000;
					signalDuration |= UART0->DR << 24;
					idx = -1;
					break;
			}
			
			WTIMER3->TAILR = signalDuration * 50.f; 
			WTIMER3->TAMATCHR = WTIMER3->TAILR * (1.f - DutyRatio / 100.f);
		}
}