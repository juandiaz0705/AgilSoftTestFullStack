/* VALIDACIONES y FORMATOS */

function calculaDV(rut) {

    // type check
    if (!rut || !rut.length || typeof rut !== 'string') {
        return -1;
    }
    // serie numerica
    var secuencia = [2, 3, 4, 5, 6, 7, 2, 3];
    var sum = 0;
    //
    for (var i = rut.length - 1; i >= 0; i--) {
        var d = rut.charAt(i)
        sum += new Number(d) * secuencia[rut.length - (i + 1)];
    };
    // sum mod 11
    var rest = 11 - (sum % 11);
    // si es 11, retorna 0, sino si es 10 retorna K,
    // en caso contrario retorna el numero
    var dv = (rest === 11 ? 0 : rest === 10 ? "K" : rest);

    return dv;
}


function formatRUTSinDV(valor) {

    // para quitarle los ceros a la izquierda
    var cuerpo = parseInt(valor).toString();
    var dv = calculaDV(cuerpo);

    // Formatear RUN
    var rut = formatMiles(cuerpo) + '-' + dv

    return rut;
}

function formatRUT(valor) {

    // Aislar Cuerpo y Dígito Verificador
    var cuerpo = parseInt(valor.slice(0, -1)).toString(); // para quitar ceros a la izquierda
    var dv = valor.slice(-1).toUpperCase();

    // Formatear RUN
    var rut = formatMiles(cuerpo) + '-' + dv

    return rut;
}

function formatMiles(value) {
    var num = value.replace(/\./g, '');

    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        value = num;
    } else {
        //alert('Solo se permiten numeros');
        value = value.replace(/[^\d\.]*/g, '');
    }
    return value;
}

function checkRut(rut) {

    if (rut.value.length == 0) {
        return false;
    }

    // Despejar Puntos
    var valor = replaceAll(rut.value, '.', '');

    // Despejar Guión
    valor = valor.replace('-', '');

    // Aislar Cuerpo y Dígito Verificador
    cuerpo = valor.slice(0, -1);

    if (cuerpo.trim().length > 0) {

        dv = valor.slice(-1).toUpperCase();
        // Formatear RUN
        rut.value = formatMiles(cuerpo) + '-' + dv

        // Si no cumple con el mínimo ej. (n.nnn.nnn)
        if (cuerpo.length < 1) {
            rut.value = '';
            alert("RUT Invalido");
            return false;
        }

        // Calcular Dígito Verificador
        suma = 0;
        multiplo = 2;

        // Para cada dígito del Cuerpo
        for (i = 1; i <= cuerpo.length; i++) {

            // Obtener su Producto con el Múltiplo Correspondiente
            index = multiplo * valor.charAt(cuerpo.length - i);

            // Sumar al Contador General
            suma = suma + index;

            // Consolidar Múltiplo dentro del rango [2,7]
            if (multiplo < 7) { multiplo = multiplo + 1; } else { multiplo = 2; }

        }

        // Calcular Dígito Verificador en base al Módulo 11
        dvEsperado = 11 - (suma % 11);

        // Casos Especiales (0 y K)
        dv = (dv == 'K') ? 10 : dv;
        dv = (dv == 0) ? 11 : dv;

        // Validar que el Cuerpo coincide con su Dígito Verificador
        if (dvEsperado != dv) {
            rut.value = '';
            alert("RUT Invalido");
            return false;
        }
    } else {
        rut.value = '';
        alert("RUT Invalido");
        return false;
    }
}

function padLeft(value, length) {
    return ('0'.repeat(length) + value).slice(-length);
}


function replaceAll(text, busca, reemplaza) {
    if (text != null && text != undefined && text != '') {
        while (text.toString().indexOf(busca) != -1)
            text = text.toString().replace(busca, reemplaza);
    }
    return text;
}

//function PadLeft(value, length) {
//    return (value.toString().length < length) ? PadLeft("0" + value, length) :
//    value;
//}

function formatDolar(valor) {
    var out = valor;
    var entero = "";
    var decimal = "";

    if (valor.length > 3) {
        entero = valor.substring(0, 3);
        decimal = valor.substring(3, valor.length);
        out = entero;// + ',' + decimal;
    } 

    return out;
    
}

function validaDetalle(string) {
    var out = '';
    var filtro = '1234567890-';//Caracteres validos

    //Recorrer el texto y verificar si el caracter se encuentra en la lista de validos 
    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            //Se añaden a la salida los caracteres validos
            out += string.charAt(i);

    //Retornar valor filtrado
    return out;
}
function soloNumeros(string) {//Solo numeros
    var out = '';
    var filtro = '1234567890';//Caracteres validos

    //Recorrer el texto y verificar si el caracter se encuentra en la lista de validos 
    for (var i = 0; i < string.length; i++)
        if (filtro.indexOf(string.charAt(i)) != -1)
            //Se añaden a la salida los caracteres validos
            out += string.charAt(i);

    //Retornar valor filtrado
    return out;
}

function format(input) {
    var num = input.value.replace(/\./g, '');
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        input.value = num;
    }

    else {
        //alert('Solo se permiten numeros');
        input.value = input.value.replace(/[^\d\.]*/g, '');
    }
}

function formatMiles(value) {
    var num = value.replace(/\./g, '');
    if (!isNaN(num)) {
        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
        num = num.split('').reverse().join('').replace(/^[\.]/, '');
        value = num;
    }

    else {
        //alert('Solo se permiten numeros');
        value = value.replace(/[^\d\.]*/g, '');
    }
    return value;
}

function soloNumerosFormatMiles(obj)
{
    var value = obj.value;
    obj.value = formatMiles(soloNumeros(value));
}


function soloNumerosKeyUp(obj) // Solo numeros
{
    obj.value = soloNumeros(this.value);
}

