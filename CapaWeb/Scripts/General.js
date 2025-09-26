function esFechaValida(fecha) {
    if (fecha != undefined && fecha.value != "" && fecha.value != "__/__/____") {
        if (!/^\d{2}\/\d{2}\/\d{4}$/.test(fecha.value)) {
            alert("Formato de fecha no válido (dd/mm/aaaa).");
            return false;
        }
        var dia = parseInt(fecha.value.substring(0, 2), 10);
        var mes = parseInt(fecha.value.substring(3, 5), 10);
        var anio = parseInt(fecha.value.substring(6), 10);

        switch (mes) {
            case 1:
            case 3:
            case 5:
            case 7:
            case 8:
            case 10:
            case 12:
                numDias = 31;
                break;
            case 4: case 6: case 9: case 11:
                numDias = 30;
                break;
            case 2:
                if (comprobarSiBisisesto(anio)) { numDias = 29 } else { numDias = 28 };
                break;
            default:
                alert("Fecha introducida errónea.");
                return false;
        }

        if (dia > numDias || dia == 0) {
            alert("Fecha introducida errónea.");
            return false;
        }
        return true;
    }
}

function comprobarSiBisisesto(anio) {
    if ((anio % 100 != 0) && ((anio % 4 == 0) || (anio % 400 == 0))) {
        return true;
    }
    else {
        return false;
    }
}