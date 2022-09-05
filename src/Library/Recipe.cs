//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------


/*Se aplica el patrón Expert, Asignar la responsabilidad al experto en información,
 la clase que tiene la información necesaria para poder cumplir con la responsabilidad.
 Recibiendo como colaboración los datos de pertinentes al precio de un step dado en la clase step, se agrega la 
 responsabilidad de calcular el precio de una serie de pasos a partir del array de pasos generados.

 Podría evaluarse crear una clase encargada exclusivamente de imprimir la receta ya que de esta manera
 el código se adecuaría mas al SRP propuesto en el curso. No se solicita modificar nada, por lo que simplemente
 se agrega responsabilidad de GetProductionCost


 Tarjeta CRC: Step
 Responsabilidades:                                                  Colaboraciones: 
 Armar un array de steps                                             step
 Funcionalidad de agregar o remover steps                            
 Imprimir receta 
 Calcular precio receta

 */

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }
        public double GetProductionCost()
        {
            double result= 0;
            foreach (Step step in this.steps )
            {
                // Para cada paso de la receta se calcula el precio generado por el producto y el equipamiento
                result = result+ (step.getProductCost(step) + step.getEquipmentCost(step));
            }
            return result;
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
            // imprimo en pantalla el resultado del método
            Console.WriteLine("El costo final de la producción es:"+ GetProductionCost() + "$" );
        }
    }
}