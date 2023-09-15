namespace webapi.inlock.codefirst.Util
    {
    public static class Criptografia
        {
        /// <summary>
        /// Gera uma hash a partir de uma senha
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static string GerarHash(string senha) => BCrypt.Net.BCrypt.HashPassword(senha);

        /// <summary>
        /// Verifica se a hash da senha informada é igual á hash do banco
        /// </summary>
        /// <param name="senhaForm">Senha passada no form de login</param>
        /// <param name="senhaBanco">Senha cadastrada no banco</param>
        /// <returns>True ou false (1 or 0)</returns>
        public static bool CompararHash(string senhaForm, string senhaBanco) => BCrypt.Net.BCrypt.Verify(senhaForm, senhaBanco);

        }
        
    }
