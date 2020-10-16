int sensor;
int saida;
void setup() {

Serial.begin(115200);
}

void loop() {

  while (Serial.available()>0) { 
  char letra = Serial.read();
  if (letra=='a')
  {
   delayMicroseconds(1000);
      sensor = analogRead(A0);
      Serial.println(sensor);
 
  }
      if (letra=='b')
      {
          saida = Serial.parseInt();
          if(saida==0) noTone(6);
          else tone(6, saida);
                
      }
  }     

}


