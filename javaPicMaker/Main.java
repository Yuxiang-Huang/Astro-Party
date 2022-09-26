import java.util.*;
import java.io.*;
import java.awt.*;

public class Main {
  public static void main(String[] args) {

    Screen s = new Screen();
    int B;
    Color c;

    for (int i = 0; i < Screen.YRES; i ++){
      B = (int) (125 - i * 0.5);
      B = Math.max(0, B);
      c = new Color (0, 0, B);
      s.drawLine(0, i, Screen.XRES-1, i, c);
    }

    s.display();
    s.saveExtension("NightSky.png");
  }//main
}//class Main
