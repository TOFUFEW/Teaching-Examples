public class Main {
    private static DBManager dbManager;
    private static SignInForm form;

    public static void main (String[] args){
        dbManager = new DBManager();
        form = new SignInForm(dbManager);
    }
}
