using CheckWeakPasswordCsv;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

try
{
    List<string> weakPass = new List<string> { };

    var usuarios = (from l in File.ReadAllLines("C:\\Users\\casey.olawuni\\usuario_202402141629.csv")
                    let split = l.Split(",")
                    where split.Length == 4
                    select new
                    {
                        UsuarioId = split[0],
                        Senha = split[1],
                        Salt = split[2],
                    }).ToList();

    foreach (var user in usuarios)
    {
        var currentPassword = CryptPass.CryptSalt("123456", user.Salt.ToString());

        if (currentPassword == user.Senha)
        {
            weakPass.Add(user.UsuarioId);
        }
    }
    File.WriteAllLines("C:\\Users\\casey.olawuni\\listaSenhasFracas.txt", weakPass);
    Console.WriteLine($"Processo concluido. {weakPass.Count()} ids de usuarios encontrados.");
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}


