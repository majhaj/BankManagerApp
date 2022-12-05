namespace BankManager.Entities.Interfaces
{
    public interface IEntity
    {
        //Wlasciwosci
        int Id { get; set; }

        //Kontrakt na metody
        string GetUniqueUserGuid(int id);

        string GetCreationProcessDescription();
    }
}
