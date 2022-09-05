//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------4

/*Se aplica el patrón Expert, Asignar la responsabilidad al experto en información,
 la clase que tiene la información necesaria para poder cumplir con la responsabilidad.
 Se generan de manera separada los metodos conocer gasto generado por el producto diferenciado del equipamiento
 por una cuestión de si después se quieren agregar descuentos o conocer los porcentajes de gasto
 simplica y ordena el código.


 Tarjeta CRC: Step
 Responsabilidades:                                                  Colaboraciones: 
 Conocer el producto de un paso                                Equipment
 Conocer el equipamiento de un paso                            Product
 Conocer cant de producto de un paso
 Conocer costo x hora equipamiento de un paso
 Conocer el gasto generado por el producto de un paso
 Conocer el gasto generado por el equiamiento  de un paso
 */
namespace Full_GRASP_And_SOLID.Library
{
    public class Step
    {
        public Step(Product input, double quantity, Equipment equipment, int time)
        {
            this.Quantity = quantity;
            this.Input = input;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Product Input { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Equipment Equipment { get; set; }

        public double getProductCost(Step paso)
        {
            double result = 0;
            result = paso.Input.UnitCost* paso.Quantity;
            return result;
        }
        public double getEquipmentCost(Step paso)
        {
            double result = 0;
            result = paso.Equipment.HourlyCost* paso.Time;
            return result;
        }
    }
}