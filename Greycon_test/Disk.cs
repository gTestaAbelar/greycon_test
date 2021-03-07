using System;
using System.ComponentModel.DataAnnotations;

namespace Greycon_test
{
    public class Disk
    {
        public int total { get; set; }
        public int used { get; set; }
        
        public int freeSpace { get { return total - used; } }

        public Disk(int totalSize, int totalUsed)
        {
           
            if(totalSize > 1000)
            {
                throw new ValidationException("TOTALOUTOFRANGE");
            }
            if (totalUsed > 1000)
            {
                throw new ValidationException("USEDOUTOFRANGE");
            }
            if (totalSize < totalUsed)
            {
                throw new ValidationException("USEDGREATHER");
            }

            total = totalSize;
            used = totalUsed;
        }

        public void Push(int mb)
        {
            used += mb;
        }

        public void Pop(int mb)
        {
            used -= mb;
        }
    }
}
