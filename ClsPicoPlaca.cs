using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClsPicoPlaca
/// </summary>
/// 
using System;
using System.Collections.Generic;
using System.Text;
public class ClsPicoPlaca

{
    public string mensaje;
    public string placa;
    public ClsPicoPlaca()
    {
        //
        // TODO: Add constructor logic here
        //

     }
    public Boolean validarPlaca(string placa, string fecha, string hora, string minuto)
    {
        bool indicadorGeneral = false;
          if (validarEsplaca(placa,fecha,hora,minuto))
        {
            indicadorGeneral = true;
        }
        else
        {
            mensaje = "La placa " + placa + " Ingresada no es valida. ABC-0123 formato correcto";
        }
        
        return indicadorGeneral;
    }

    public bool validarLongitud(string placa)
    {
        bool indicador = false;
        if (placa.Length < 8 || placa.Length > 8)
        {
            indicador = false;
        }
        else
        {
            indicador = true;
                }
        return indicador;
    }

    public bool validarEsplaca(string placa, string fecha, string hora, string minuto )
    {

        bool indicador = false;
        string digitos1, digitos2, digitos3;
        if (validarLongitud(placa))
        {
            digitos1 = placa.Substring(0, 3);
            digitos2 = placa.Substring(3, 1);
            digitos3 = placa.Substring(4, 4);
            if (validarDigito1(digitos1) && validarDigito2(digitos2) && validarDigito3(digitos3))
            {
                indicador = true;
               if  (validarMovilidad(digitos3, fecha, hora, minuto)) { 
                    mensaje = "El vehiculo con la placa numero.." + placa + " puede circular en este dia";
                }
                else
                {
                    mensaje = "El vehiculo con la placa numero.." + placa + " Fuera de horario de circulacion";
                }
            }
            else
            {
                indicador = false;
            }
         
        }
        else
        {
            indicador = false;
        }
        

        return indicador;
    }

    public bool validarDigito1(string digito1)
    {
    
        bool indicador = true;
       
            foreach (char ch in digito1)
            {
                if (!Char.IsLetter(ch) && ch != 32)
                {
                indicador = false;
                }
            }
         
            return indicador;
    }
    public bool validarDigito2(string digito2)
    {
        bool indicador = true;
        if (digito2 !="-" )
        {
            indicador = false;
        }
        return indicador;
    }
    public bool validarDigito3(string digito3)
    {
        bool indicador = true;
        int i = 0;
        if (int.TryParse(digito3,out i))
        {
            
            indicador = true;
        }
        else
        {
            indicador = false;
        }

        return indicador;
    }
    
    public bool validarMovilidad(string placa, string fecha, string hora, string minuto)
    {
        bool esValida = false;
        DateTime fechas = Convert.ToDateTime(fecha);
        string dia = fechas.DayOfWeek.ToString();
        int dias = Convert.ToInt16(fechas.DayOfWeek);
        int ultimoDigito = Convert.ToInt16(placa.Substring(3, 1));

        int h = Convert.ToInt16(hora);
        int m = Convert.ToInt16(minuto);
        esValida = validarHora(esValida, dias, ultimoDigito, h, m);

        return esValida;
    }

    private static bool validarHora(bool esValida, int dias, int ultimoDigito, int h, int m)
    {
        esValida = false;
        if (validarHora(h, m) == false)
        {


            switch (dias)
            {
                case 1:
                    if ((ultimoDigito == 1 || ultimoDigito == 2))
                    {

                        esValida = true;
                    }
                    break;
                case 2:
                    if (ultimoDigito == 3 || ultimoDigito == 4)
                    {
                        esValida = true;
                    }
                    break;

                case 3:
                    if (ultimoDigito == 5 || ultimoDigito == 6)
                    {
                        esValida = true;
                    }
                    break;

                case 4:
                    if (ultimoDigito == 7 || ultimoDigito == 8)
                    {
                        esValida = true;
                    }
                    break;

                case 5:
                    if (ultimoDigito == 9 || ultimoDigito == 0)
                    {
                        esValida = true;

                    }

                    break;
                case 6:
                    esValida = true;
                    break;
                case 7:
                    esValida = true;
                    break;


                default:
                    break;

            }
            

        }
        else
        {
            esValida = true;
        }

        return esValida;
    }

    private static bool validarHora(int h, int m) {
        bool eshoraValida = false;
    string horaMinuto = Convert.ToString(h) + ":" + Convert.ToString(m);
    DateTime horaIngreso = Convert.ToDateTime(horaMinuto);
    DateTime horaMan1 = Convert.ToDateTime("7:00");
    DateTime horaMan2 = Convert.ToDateTime("9:30");
    DateTime horaTar1 = Convert.ToDateTime("16:00");
    DateTime horaTard2 = Convert.ToDateTime("19:30");
        if ((horaIngreso >= horaMan1 && horaIngreso <= horaMan2) || (horaIngreso >= horaTar1 && horaIngreso <= horaTard2))
        {

            eshoraValida = false;
        }
        else
        {
            eshoraValida = true;
        }
        return eshoraValida;
    }
    
}