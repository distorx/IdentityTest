using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace TestIdentity.Infrastructure {
    public class CustomPasswordValidator : PasswordValidator {
        public override async Task<IdentityResult> ValidateAsync(string pass) {
            IdentityResult result = await base.ValidateAsync(pass);
            if (pass.Contains("12345")) {
                var errors = result.Errors.ToList();
                errors.Add("Password cannont contain numeric sequences");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}