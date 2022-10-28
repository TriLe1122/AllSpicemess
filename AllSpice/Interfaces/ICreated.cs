namespace AllSpice.Interfaces;


public interface ICreated
{
  string creatorId { get; set; }

  Profile Creator { get; set; }
}