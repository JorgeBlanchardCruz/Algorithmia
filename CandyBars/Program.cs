/* Alice y Bob tienen barras de caramelo de diferentes tamaños:
 * A[i] es el tamaño de la i-ésima barra de caramelo que tiene Alice
 * B[j] es el tamaño de la j-ésima barra de caramelo que tiene Bob
 * 
 * Como son amigos, les gustaría intercambiar una barra de chocolate cada uno para que después del intermcabio, 
 * ambos tengan el mismo tamaño total de dulces
 * (La cantidad total de dulces que tiene una persona es la suma de los tamaños de las barras de dulce que tiene)
 * 
 * Devuelve una matriz de números enternos ans donde ans[0] es el tamaño de la barra de chocolate que Alice debe intercambiar y
 * and[1] es el tamaño de la barra de chocolate que Bob debe intermcabiar
 * 
 * Si hay varias respuestas, puede devolver cualquiera de ellas.
 * Está garantizado que existe una respuesta.
 * 
 * Ejemplo
 * A = [7,3,2,4]
 * B = [6,1,5]
 * Devuelve [7,5]
 * 
 */

//7+3+2+4   = 16
//6+1+5     = 12

//5+3+2+4   = 14
//6+1+7     = 14


using CandyBars;

//List<int> A = new() { 7, 3, 2, 4 };
//List<int> B = new() { 6, 1, 5 };

//List<int> A = new() { 5, 3, 2, 4 };
//List<int> B = new() { 6, 1, 7 };

//List<int> A = new() { 4, 3, 2, 8 };
//List<int> B = new() { 6, 1, 6 };

List<int> A = new() { 3, 1, 7, 11, 2, 9 };
List<int> B = new() { 8, 8, 12, 3, 2, 4 };


var candyOperator = new CandiesOperator();
var result = candyOperator.HandingOutCandy(A, B);


Console.WriteLine($"result [{result[0]}, {result[1]}]");
Console.WriteLine($"SumA {candyOperator.SumCandyLen(A)}");
Console.WriteLine($"SumB {candyOperator.SumCandyLen(B)}");

Console.WriteLine($"resutlA{candyOperator.SumCandyLen(A)  - result[0] + result[1]}");
Console.WriteLine($"resutlB {candyOperator.SumCandyLen(B) - result[1] + result[0]}");

Console.ReadKey();

