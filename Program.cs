using System.Net.Http.Headers;
using System.Runtime.Intrinsics.Arm;

int elementCount = 8000000;
int stepCount = 4;
int bytesPerElement = 4;
double bytesPerMiB = 1024.0 * 1024;
List<int[]> blocks = new List<int[]>();

long startMemory = Environment.WorkingSet;
System.Console.WriteLine($"Step 0. Рабочий набор: {startMemory / bytesPerMiB:F2} Mib");
for (int step = 1; step <= stepCount; step++)
{
    System.Console.WriteLine("Press Enter");
    System.Console.ReadLine();

    int[] block = new int[elementCount];
    for (int i = 0; i < block.Length; i++)
    {
        block[i] = 1;
    }
    blocks.Add(block);

    long currentMemory = Environment.WorkingSet;
    long dataBytes = 1L * blocks.Count * elementCount * bytesPerElement;
    System.Console.WriteLine($"Step {step}. Сохранено массивов: {blocks.Count}");
    System.Console.WriteLine($"Объем елементов: {dataBytes / bytesPerMiB:F2} MiB");
    System.Console.WriteLine($"Рабочий набор: {currentMemory / bytesPerMiB:F2} MiB");
    System.Console.WriteLine($"Изменение от начала: {(currentMemory - startMemory) / bytesPerMiB:F2} MiB");
}
System.Console.WriteLine("Данные сохранены в памяти. Нажмите Enter для завершения.");
System.Console.ReadLine();
long check = 0;
foreach(int[] block in blocks)
{
    check += block[0];
}
System.Console.WriteLine($"Контрольная суммапервых элементов: {check}");