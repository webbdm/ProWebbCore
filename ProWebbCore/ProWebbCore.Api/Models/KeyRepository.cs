using System.Collections.Generic;
using System.Linq;
using ProWebbCore.Shared.Numbers;

namespace ProWebbCore.Api.Models
{
    public class KeyRepository
    {
        private readonly AppDbContext _appDbContext;

        public KeyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Key> GetAllKeys()
        {
            return _appDbContext.Key.ToList();
        }

        public Key GetKeyById(int keyId)
        {
            Key key = _appDbContext.Key.Where(k => k.ID == keyId).FirstOrDefault();

            key.Notes = (from kn in _appDbContext.KeyNote
                         join k in _appDbContext.Key on kn.KeyID equals k.ID
                         join n in _appDbContext.Note on kn.NoteID equals n.ID
                         where kn.KeyID == keyId
                         select new KeyNote
                         {
                             NoteName = n.NoteName,
                             Number = kn.Number
                         }).ToList();

            return key;
        }

    }
}