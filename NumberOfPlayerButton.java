import javax.swing.JOptionPane;
import javax.swing.SwingUtilities;

public class NumberOfPlayerButton
{   
    public static void main(String[] args)
    {
        SwingUtilities.invokeLater(new Runnable()
        {
            @Override
            public void run()
            {
              Object[] options = {"Four","Three","Two"};
              int choice = JOptionPane.showOptionDialog(null, 
                  "How many players are playing?", 
                  "Number Of Players", 
                  JOptionPane.YES_NO_OPTION, 
                  JOptionPane.QUESTION_MESSAGE, 
                  null, options, options[2]);
             
              // interpret the user's choice
              if (choice == JOptionPane.YES_NO_OPTION)
              {
                System.exit(0);
              }
            }
        });
    }
}