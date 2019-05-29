import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import java.util.Date;

public class SignInForm {
    private JFrame frame;
    private DBManager dbManager;
    private JLabel title;
    private JTextField fName;
    private JTextField lName;
    private JButton sbmtBtn;
    private JLabel fNameLabel;
    private JLabel lNameLabel;
    public JPanel formView;

    public SignInForm(DBManager dbManager){
        frame = new JFrame("Sign In Form");
        frame.setContentPane(formView);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.pack();
        frame.setVisible(true);

        this.dbManager = dbManager;

        sbmtBtn.addActionListener(new Submit());

        frame.getRootPane().setDefaultButton(sbmtBtn);
    }

    private class Submit implements ActionListener{
        @Override
        public void actionPerformed(ActionEvent e){
            write(formString());
            Component frame = new JFrame();
            JOptionPane.showMessageDialog(frame, "Signed In!");
            fName.setText("");
            lName.setText("");
        }
    }

    private String formString(){
        Date date = new Date();
        String str = date.toString() + "," + fName.getText() + "," + lName.getText() + "\n";
        return str;
    }

    private void write(String content){
        dbManager.write(content);
    }
}
