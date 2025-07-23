using Commons.Models;

Nokia nokia = new(numero: "911112222", modelo: "Nokia Tijolão", imei: "11111111111", memoria: 256);
Smartphone.Ligar();
nokia.InstalarAplicativo("WhatsApp");
Smartphone.ReceberLigacao();

Iphone iphone = new(numero: "911112222", modelo: "Iphone 20", imei: "22222222222", memoria: 164);
Smartphone.Ligar();
iphone.InstalarAplicativo("Telegram");
Smartphone.ReceberLigacao();