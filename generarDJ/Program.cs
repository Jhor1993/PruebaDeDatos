// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json.Linq;

Console.WriteLine("Ingresar nro formulario:");
string nroFormulario = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Ingresar CUIT:");
string cuit = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Ingresar año:");
string anio = Console.ReadLine() ?? string.Empty;

Console.WriteLine("Ingresar id dj inicial:");
long idDJ = long.Parse(Console.ReadLine());

string s5220 = "{\"header\":{\"idPerson\":27957925753,\"tax\":4,\"period\":20211200,\"quota\":12,\"asset\":\"\",\"amount\":0},\"Registros\":{\"ID_DJ\":635376,\"Fecha_operacion\":\"2022-01-21T14:23:11.0177181-03:00\",\"Fecha_presentacion\":\"2022-01-21T14:23:11.0177181-03:00\",\"Fecha_vencimiento\":\"2022-01-14T00:00:00\",\"Concepto\":0,\"Razon_social\":\"SHU XUEMEI\",\"Fecha_pago\":\"2022-01-24T00:00:00\",\"ISIB\":156169008,\"Total_ingresos_no_grabados\":0,\"Total_ingresos_exentos\":0,\"Total_deducciones\":0,\"Conceptos_no_integran_base_imponible\":0,\"Retenciones\":0,\"Percepciones\":0,\"Pagos_a_cuenta\":0,\"Saldos_favor\":0,\"Impuesto_determinado\":50000,\"Otros_debitos\":0,\"Otros_creditos\":0,\"Mecenazgo\":0,\"Diferimiento\":0,\"Compania_de_seguros\":0,\"Credito_periodo_anterior\":0,\"Saldo_favor_no_monetario_a_reimputar\":0,\"Saldo_favor_monetario_a_reimputar\":0,\"Pago_mecenazgo_promotor\":0,\"Pago_mecenazgo_benefactor\":0,\"Promocion_hotelera\":0,\"Saldo_favor_anual_cia_seguros\":0,\"Fibra_optica\":0,\"Pago_cuenta_empresas_de_transporte\":0,\"Pago_cuenta_mecenazgo\":0,\"Pago_cuenta_pago_inscripcion\":0,\"Pago_cuenta_plan_facilidades\":0,\"Pago_cuenta_promocion_hotelera\":0},\"Actividades\":[{\"Descripcion\":\"\",\"Cod_actividad\":471130,\"Alicuota\":3,\"Base_imponible\":2660818.84,\"Impuesto_actividad\":79824.57}]}";
JObject json5220 = JObject.Parse(s5220);

string s5866 = "{\"header\":{\"idPerson\":20369233647,\"period\":20210200,\"tax\":2,\"asset\":\"\",\"quota\":2,\"amount\":0},\"Registros\":{\"ID_DJ\":207807767,\"Tipo_dj\":4,\"Fecha_presentacion\":\"2021-02-24T00:00:00.000-03:00\",\"Fecha_operacion\":\"2022-04-05T23:07:00.000-03:00\",\"Concepto\":0,\"Razon_social\":\"xxxxx xx xxxxx xxxx x.x.\",\"Inscripto\":\"7777777777\",\"Cod_jurisdiccion\":901,\"Base_imponible\":0,\"Impuesto_determinado\":566067.54,\"Ingresos_gravados\":0,\"Ingresos_no_gravados\":0,\"Ingresos_exentos\":0,\"Coeficiente_unificado\":0,\"Saldos_a_favor_periodos_anteriores\":0,\"Percepciones_soportadas\":0,\"Compensaciones_percepcion\":0,\"Retenciones_bancarias\":0,\"Retenciones\":0,\"Percepciones_aduaneras\":0,\"Otros_debitos\":0,\"Creditos_anticipo\":0,\"Pagos_no_bancarios\":0,\"Mecenazgo\":0,\"Diferimiento\":0,\"Compania_de_seguros\":0,\"Otros_creditos\":0,\"Fibra_optica\":0,\"Promocion_hotelera\":0,\"Pago_cuenta_empresas_carga_camiones\":0,\"Monto_exportacion\":0,\"Ingresos_totales\":0,\"Monto_imponible_art_2\":0,\"Monto_imponible_inicio_de_actividad\":0,\"Monto_imponible_regimenes_especiales\":0,\"Transaccion_afip\":\"777777777\"},\"Jurisdicciones\":[{\"Cod_jurisdiccion\":901,\"Coeficiente_unificado\":0}],\"Actividades\":[{\"Cod_actividad\":641930,\"Cod_regimen\":8,\"Tratamiento_fiscal\":0,\"Base_imponible\":20149272.2,\"Base_ajustada\":20149272.2,\"Alicuota\":8,\"Impuesto_actividad\":1611941.78}]}";
JObject json5866 = JObject.Parse(s5866);

string s5225 = "{\"header\":{\"idPerson\":99123456789,\"period\":20210100,\"tax\":20,\"asset\":\"\",\"quota\":1,\"amount\":0},\"Registros\":{\"ID_DJ\":123,\"Fecha_operacion\":\"2020-01-08\",\"Fecha_presentacion\":\"2020-01-08\",\"Fecha_vencimiento\":\"2020-01-01\",\"Razon_social\":\"ABCDEFGH\",\"Concepto\":0,\"Tipo_agente\":\"ABCDEFGHIJKL\",\"Situacion_IVA\":\"ABCDEFGH\",\"Domicilio_fiscal\":\"ABCDEFGHI\",\"Nro_agente\":123,\"Nombre_apellido\":\"Pablo Calligo\",\"Caracter_de\":\"ABCDEFGHI\",\"Tipo_doc\":\"DNI\",\"Nro_documento\":369233646,\"Total_ret_percep_practicadas\":200000,\"Total_pagos_a_cuenta\":0,\"Total_notas_credito\":0,\"Total_DJ\":200000,\"Monto_interes\":0,\"Monto_retardo\":0,\"Importe_a_depositar\":200000},\"Retenciones\":[{\"Descripcion\":\"ABCDEFGHIJKL\",\"Alicuota\":1,\"Registros\":1,\"Monto\":100000,\"Monto_retenido\":100000}],\"Percepciones\":[{\"Descripcion\":\"ABCDEFGH\",\"Alicuota\":1,\"Registros\":1,\"Monto\":100000,\"Monto_percibido\":100000}]}";
JObject json5225 = JObject.Parse(s5866);

JObject? jsonForm = nroFormulario switch
{
    "5220" => json5220,
    "5866" => json5866,
    "5225" => json5225,
    _ => null
};

string path = $"{Directory.GetCurrentDirectory()}\\{nroFormulario}_{cuit}_{DateTime.Now:yyyy-MM-ddTHH-mm-ss}.txt";

JArray resultado = new();
if (jsonForm != null)
{
    long impuestoDeterminado = 50000;

    for (int i = 1; i <= 12; i++)
    {
        string periodo = $"{anio}{i.ToString().PadLeft(2, '0')}00";
        JObject nuevoItem = (JObject)jsonForm.DeepClone();

        nuevoItem.Value<JObject>("header")["idPerson"] = long.Parse(cuit);
        nuevoItem.Value<JObject>("header")["period"] = int.Parse(periodo);
        nuevoItem.Value<JObject>("header")["quota"] = i;
        nuevoItem.Value<JObject>("Registros")["ID_DJ"] = idDJ;
        nuevoItem.Value<JObject>("Registros")["Impuesto_determinado"] = impuestoDeterminado; ;


        resultado.Add(nuevoItem);

        idDJ++;
        impuestoDeterminado += 50000;
    }

    if (System.IO.File.Exists(path))
        System.IO.File.Delete(path);
    
    System.IO.File.WriteAllText(path, resultado.ToString());
}
