using Esercizio_U5_S1_L1.ViewModels;
using FluentEmail.Core;

namespace Esercizio_U5_S1_L1.Services {
    public class EmailService {
        private readonly IFluentEmail _fluentEmail;

        public EmailService(IFluentEmail fluentEmail) {
            _fluentEmail = fluentEmail;
        }

        public async Task<bool> SendEmail(string productName, string productDescription) {
            var emailViewModel = new EmailViewModel() {
                Name = productName,
                Description = productDescription,
            };

            var res = await _fluentEmail.To("samu.converso@gmail.com").Subject("New product")
                .UsingTemplateFromFile("Views/Templates/EmailTemplate.cshtml", emailViewModel)
                .SendAsync();

            return res.Successful;
        }
    }
}
