using RestAlpaka.Model;

namespace RestAlpaka.Managers
{
    public class AlpakaManager : BaseDBContext<Alpaka>
    {

        public AlpakaManager(AlpakaDbContext context) : base(context)
        {

        }

        //public async Task<int> CreateAlpakaAsync(Alpaka alpaka)
        //{
        //    if (string.IsNullOrEmpty(alpaka.color) || alpaka.ImageFile == null || string.IsNullOrEmpty(alpaka.Alpaka_name) || string.IsNullOrEmpty(alpaka.description))
        //    {
        //        // Handle the case where required fields are not provided
        //        throw new InvalidOperationException("Required fields are missing or invalid.");
        //    }

        //    if (alpaka.ImageFile != null)
        //    {
        //        using (var stream = alpaka.ImageFile.OpenReadStream())
        //        {
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                await stream.CopyToAsync(ms);
        //                alpaka.ImageData = ms.ToArray();
        //            }
        //        }
        //    }

        //    // Insert the entity into the DbSet
        //    _dbSet.Add(alpaka);

        //    // Save changes to the database
        //    await _dbContext.SaveChangesAsync();

        //    return alpaka.alpaka; // Assuming 'alpaka' is the identifier property
        //}



        // Here you can override any virtual methods from BaseDBContext<T> if needed.
        // You can also add any additional methods specific to AlpakaManager.
    }
}