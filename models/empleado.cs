using System;

namespace TP2.models
{
    public class Empleado
    {
        /// <summary>
        /// 1) Curiosidad: Poner 3 slash seguidos autogenera la estructura de este <summary>
        /// 2) No hay mucho para explicar, como mucho el override de ToString
        /// </summary>
        private string? _nombre;
        private string? _apellido;
        private double? _salario;

        public Empleado() { }
        public Empleado(string Nombre, string Apellido, double Salario)
        {
            _nombre = Nombre;
            _apellido = Apellido;
            _salario = Salario;
        }
        public string? Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string? Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public double? Salario
        {
            get { return _salario; }
            set { _salario = value; }
        }
        public override string ToString()
        {
            return $"Nombre: {Nombre}.\nApellido: {Apellido}. \nSalario: $ {Salario}.";
        }
    }
}