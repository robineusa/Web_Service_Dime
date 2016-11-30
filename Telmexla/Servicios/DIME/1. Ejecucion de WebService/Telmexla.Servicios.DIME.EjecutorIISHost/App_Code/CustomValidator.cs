using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;


/// <summary>
/// Descripción breve de CustomValidator
/// </summary>
public class CustomValidator : UserNamePasswordValidator
{


    public override void Validate(string userName, string password)
    {
        AccountModel model = new AccountModel();
        if (model.login(userName, password))
            return;
        throw new SecurityTokenException("Account's invalid");
    }
}