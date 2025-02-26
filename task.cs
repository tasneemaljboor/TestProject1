package org.task;
import io.github.bonigarcia.wdm.webDriverManger;
import org.openqa.selenium.webDriver; 
import org.openqa.selenium.chrome.chromeDriver;

public class Class1
{
	
		public static void main(string{}
		args)
			{
            webDriverManger.chromdriver().setup();
	webDriver driver = new chromeDriver();
	driver.manage().window().maximize();
	driver.get("https://localhost:44349/");
		driver.findElement(by.linktext("login")).click();
	driver.findElement(by.id("email")).sendkeys("sajedbushehab@yahoo.com") ;
	driver.findElement(by.id("mypass1").sendkeys("123456");
    driver.findElement(by.cssSelector("button[name=\"login-button\"]")).submit();
    thread.sleep(5000);
		driver.quit()
        driver.findElement(by.linktext("fas fa fa-shopping-cart fa-lg")).click();
    driver.findElement(by.linktext("href="/User/PayForTheOrder"")).click();
    driver.findElement(by.name("cardholderame")).sendkeys("AhmadOmari");
    driver.findElement(by.name("cardNumber")).sendkeys("1234123412340000");
    driver.findElement(by.name("cvv")).sendkeys("357");
    driver.findElement(by.name("expire")).sendkeys("2030-10");
    driver.findElement(by.cssSelector("button[name=\"pay-button\"]")).submit();
    thread.sleep(5000);
		driver.quit()
}
	

