namespace Greycon_test
{
    public class Utils
    {
        private static int getMostEmpty(DiskSet disksSet, bool[] marks)
        {
            int freeSpace = 0;
            int indice = -1;
            for (int i = 0; i < disksSet.Disks.Length; i++)
            {
                if (!marks[i] && freeSpace < disksSet.Disks[i].freeSpace)
                {
                    indice = i;
                    freeSpace = disksSet.Disks[i].freeSpace;
                }
            }
            return indice;
        }

        private static int getNextMostEmpty(DiskSet disksSet, bool[] marks, int index)
        {
            int freeSpace = 0;
            int indice = -1;
            for (int i = 0; i < disksSet.Disks.Length; i++)
            {
                if (!marks[i] && freeSpace <= disksSet.Disks[i].freeSpace && disksSet.Disks[i].used > 0 && i != index)
                {
                    indice = i;
                    freeSpace = disksSet.Disks[i].freeSpace;
                }
            }
            return indice;
        }

        private static int getDisksUsed(DiskSet disksSet)
        {
            int result = 0;
            for (int i = 0; i < disksSet.Disks.Length; i++)
            {
                if (disksSet.Disks[i].used > 0) result += 1;
            }
            return result;
        }

        public static int packData(DiskSet disksSet)
        {
            bool[] marks_i = new bool[disksSet.Disks.Length]; //Arreglo para marcar los indices ya utilizados para llenar el disco
            bool[] marks_j = new bool[disksSet.Disks.Length]; //Arreglo para marcar los indices de los demas disksSet de donde tomar elementos.
            int i = getMostEmpty(disksSet, marks_i);
            if (i > -1) marks_i[i] = true;
            int j = getNextMostEmpty(disksSet, marks_j, i);
            if (j > -1) marks_j[j] = true;
            int usedDisks;

            while (i != -1 && j != -1)
            {
                if (disksSet.Disks[j].used < disksSet.Disks[i].freeSpace)
                {
                    disksSet.Disks[i].Push(disksSet.Disks[j].used);
                    disksSet.Disks[j].Pop(disksSet.Disks[j].used);
                }
                else
                {
                    disksSet.Disks[j].Pop(disksSet.Disks[i].freeSpace);
                    disksSet.Disks[i].Push(disksSet.Disks[i].freeSpace);
                }

                if (disksSet.Disks[i].freeSpace == 0)
                {
                    i = getMostEmpty(disksSet, marks_i);
                    if (i > -1) marks_i[i] = true;
                    //ahora limpiamos el arreglo marks_j , pero le marcamos los que ya fueron llenados, para no sacar elementos de esos.
                    for (int k = 0; k < marks_j.Length; k++)
                    {
                        marks_j[k] = marks_i[k];
                    };
                }
                j = getNextMostEmpty(disksSet, marks_j, i);
                if (j > -1) marks_j[j] = true;
            }

            usedDisks = getDisksUsed(disksSet);


            return usedDisks;
        }
    }
}
