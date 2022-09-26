import java.util.*;
import java.io.*;
import java.awt.*;

public class Main {
  public static void main(String[] args) {

    Screen s = new Screen();
    int B = 255;
    Color c;

    for (int i = 0; i < Screen.YRES; i ++){
      c = new Color (255, 255, B);
      s.drawLine(Screen.XRES/2, 0, Screen.XRES/2, Screen.YRES-1, c);
    }

    s.display();
    s.saveExtension("NightSky.png");
  }//main
}//class Main
