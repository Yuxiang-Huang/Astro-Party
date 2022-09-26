import java.util.*;
import java.io.*;
import java.awt.*;
import java.lang.*;

public class Main {
  public static void main(String[] args){

    Screen s = new Screen();
    int B;
    Color c;

    for (int i = Screen.YRES - 1; i >= 0; i --){
      B = (int) (125 - i * 0.5);
      B = Math.max(0, B);
      c = new Color (0, 0, B);
      s.drawLine(0, i, Screen.XRES-1, i, c);
    }

    c = new Color (255, 255, 255);

    for (int i = 0; i < 100; i ++){
      Point rand = new Point ((int) (Math.random() * Screen.XRES),
      (int) (Math.random() * Screen.YRES));
      s.drawLine(rand.x - 1, rand.y, rand.x + 1, rand.y, c);
      s.drawLine(rand.x, rand.y - 1, rand.x, rand.y + 1, c);
    }

    s.display();
    s.saveExtension("NightSky.png");
  }//main
}//class Main
