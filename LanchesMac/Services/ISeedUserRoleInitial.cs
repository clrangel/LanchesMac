namespace LanchesMac.Services
{
    public interface ISeedUserRoleInitial
    {
        //Implementa a crição dos perfis
        void SeedRoles();
        //Implementa a criação dos usuários e atribuiu usuários aos perfis
        void SeedUsers();
    }
}
