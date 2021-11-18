# Cognia.Technology.Case


Tanker om database oppsett.

![cognia_db_diagram](https://user-images.githubusercontent.com/44683197/141870130-7a0cf87a-01bd-4c2f-b4e6-3ec2c0cabe43.png)


Tanker om flyt i arkitektur
![Cognia-Technology-Diagram1](https://user-images.githubusercontent.com/44683197/141870644-6e224c58-b727-4fef-a264-7161c7703a3a.png)

Spørsmål 1 Hvilke data om en bruker og brukeraktivitet ville du logget og hvorfor?

-Hvilke funksjoner brukeren bruker mest. 
-Type kunde. 
-Innlogginger
-Når kunden kunden bruker diverse funksjoner. 
-Firma. 
-systemet brukeren bruker.


Lag et design utkast/konsept du ville benyttet for å logge brukeraktivitet i en mikrotjenestearkitektur?

Men vil først og fremst behandle dette forskjellig utifra loglevel typ [information] [warning] [error] [critical].
Ta information f.eks [Tid] [loglevel] [HTTPVERB] [Service?] [Action] [CustomerToken/noen form for Id]
Error eks: [tid] [logvel] [exception] 


![image](https://user-images.githubusercontent.com/44683197/142301596-79eecc61-6495-4574-bf06-11f218ca7349.png)


