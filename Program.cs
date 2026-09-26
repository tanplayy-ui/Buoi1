Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("=== Chuong trinh doan so ===");
Random random = new Random();
int targetNumber = random.Next(100, 1000);
string targetString = targetNumber.ToString();
int attempt = 1, MAX_GUESS = 7;
string guess, feedback = "";
while (feedback != "+++" && attempt <= MAX_GUESS)
{
    Console.Write("Lan doan thu {0}: ", attempt);
    guess = Console.ReadLine();
    if (guess == null || guess.Length != 3 || !int.TryParse(guess, out int soDoan) || soDoan < 100 || soDoan > 999)
    {
        Console.WriteLine("=> Vui long nhap mot so co dung 3 chu so (100-999).");
        continue;
    }

    feedback = GetFeedback(targetString, guess);
    Console.WriteLine("Phan hoi tu may tinh: {0}", feedback);
    attempt++;
}
if (feedback == "+++")
    Console.WriteLine("Nguoi choi da doan dung! Tro choi ket thuc sau {0} lan doan.", attempt - 1);
else
    Console.WriteLine("Nguoi choi thua cuoc. So can doan la: {0}", targetNumber);

Console.WriteLine("Nhan phim bat ky de thoat...");
static string GetFeedback(string target, string guess)
{
    string feedback = "";

    for (int i = 0; i < target.Length; i++)
    {
        if (target[i] == guess[i])
            feedback += "+";
        else if (target.Contains(guess[i].ToString()))
            feedback += "?";
    }

    return feedback;
}