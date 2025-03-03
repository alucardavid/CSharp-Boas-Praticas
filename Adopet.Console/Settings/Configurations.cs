﻿using Microsoft.Extensions.Configuration;

namespace Adopet.Console.Settings
{
    public static class Configurations
    {
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets("e68c378d-416e-468f-9d8d-24f81026ddfa")
                .Build();
        }

        public static ApiSettings ApiSetting
        {
            get
            {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(ApiSettings.Section)
                    .Get<ApiSettings>() ??
                    throw new ArgumentException("Seção para configuração da API não encontrada!");
            }
        }

        public static MailSettings MailSetting
        {
            get
            {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(MailSettings.EmailSection)
                    .Get<MailSettings>() ??
                    throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
            }
        }
    }
}
