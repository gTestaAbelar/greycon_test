namespace Greycon_test
{
    public class Utils
    {
        /*
            Esta funcion devuelve el proximo disco (que no fue utilizado previamente) a ser llenado, buscando siempre el que tenga mayor espacio libre.  
         */
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

        /*
            Esta funcion devuelve el disco (que no fue utilizado previamente) de donde tomar bytes para llenar el seleccionado por getMostEmpty, buscando siempre el que tenga menos espacio usado.
            (equivalente a mayor espacio libre)
         */
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

        /*
            Esta funcion devuelve la cantidad de discos que no estan vacios, que sirve para determinar el resultado de la solucion.
         */
        private static int getDisksUsed(DiskSet disksSet)
        {
            int result = 0;
            for (int i = 0; i < disksSet.Disks.Length; i++)
            {
                if (disksSet.Disks[i].used > 0) result += 1;
            }
            return result;
        }

        /*
            Esta funcion es la que lleva a cabo la solucion del problema planteado.
            La idea es buscar primero los discos con mayor espacio libre, e ir llenandolos con los demas discos. Cuando se llena se pasa al siguiente con mayor espacio libre y se repite el proceso,
            hasta que no haya mas discos por llenar. Cada disco que se llena se marca, para que al llenar el proximo, no sea tomado en cuenta para sacar datos.
            Cuando no haya de donde sacar datos o no haya disco para llenar, termina el proceso.
            Al terminar, se recorren los discos sumando la cantidad de discos no vacios, para luego devolver ese valor como resultado.
         */
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
