import java.io.File;
import java.io.FileWriter;

public class DBManager {
    File file;
    FileWriter fw;

    public DBManager(){
        file = new File("SignInLog.csv");

        if (!file.exists()){
            try {
                file.createNewFile();
            } catch (Exception e){
                System.out.println(e);
            }
        }
    }

    public void write(String content){
        try {
            fw = new FileWriter(file, true);
            fw.write(content);
            fw.close();
        } catch (Exception e){
            System.out.println(e);
        }
    }
}
