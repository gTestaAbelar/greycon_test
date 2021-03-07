using System.ComponentModel.DataAnnotations;

namespace Greycon_test
{
    public class DiskSet
    {
        [MaxLength(50)]
        public Disk[] Disks { get; set; }

        public DiskSet(int[] used, int[] total)
        {
            if(used.Length != total.Length)
            {
                throw new ValidationException("NOTEQUALS");
            }

            if (total.Length > 50)
            {
                throw new ValidationException("TOOLARGE");
            }

            Disks = new Disk[total.Length];
            for(int i = 0; i < Disks.Length; i++)
            {
                Disks[i] = new Disk(total[i], used[i]);
            }
        }
    }
}
