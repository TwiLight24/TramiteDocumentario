function DesactivaDiasNoLaborablesInicio(sender, args) {

    var idCelda;
    var filagrilla;

    //strValorCelda = "ContentPlaceHolder1_gvwRegHoras_cldFecha_0_day_5_0"
    for (var i = 0; i < sender._days.all.length; i++) {
        for (var j = 0; j < 6; j++) {

            if (sender._days.all[i].id != '') {
                idCelda = sender._days.all[i].id;
                idCelda = idCelda.substring(20, 80);
                if (idCelda.substring(0, 9) == "cldFecha_") {

                    //Desactiva Domingos (0) y Sabados (6)
                    if ((idCelda == "cldFecha_day_" + j + "_0") ||
                        (idCelda == "cldFecha_day_" + j + "_6")) {
                        sender._days.all[i].disabled = true;
                        sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                    }
                    //Para el resto de días, la desactivación es de acuerdo a Arreglo
                    if ((idCelda == "cldFecha_day_" + j + "_1") ||
                        (idCelda == "cldFecha_day_" + j + "_2") ||
                        (idCelda == "cldFecha_day_" + j + "_3") ||
                        (idCelda == "cldFecha_day_" + j + "_4") ||
                        (idCelda == "cldFecha_day_" + j + "_5")) {

                        sender._days.all[i].disabled = false;
                        for (var k = 0; k < arrayDiasFeriados.length; k++) {
                            if (Number(sender._days.all[i].innerText) == Number(arrayDiasFeriados[k].substring(6, 8))) {
                                sender._days.all[i].disabled = true;
                                sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

function DesactivaDiasNoLaborablesFin(sender, args) {
    var idCelda;
    var filagrilla;

    //strValorCelda = "ContentPlaceHolder1_gvwRegHoras_cldFecha_0_day_5_0"
    for (var i = 0; i < sender._days.all.length; i++) {
        for (var j = 0; j < 6; j++) {

            if (sender._days.all[i].id != '') {
                idCelda = sender._days.all[i].id;
                idCelda = idCelda.substring(20, 80);
                if (idCelda.substring(0, 9) == "cldFechb_") {

                    //Desactiva Domingos (0) y Sabados (6)
                    if ((idCelda == "cldFechb_day_" + j + "_0") ||
                        (idCelda == "cldFechb_day_" + j + "_6")) {
                        sender._days.all[i].disabled = true;
                        sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                    }
                    //Para el resto de días, la desactivación es de acuerdo a Arreglo
                    if ((idCelda == "cldFechb_day_" + j + "_1") ||
                        (idCelda == "cldFechb_day_" + j + "_2") ||
                        (idCelda == "cldFechb_day_" + j + "_3") ||
                        (idCelda == "cldFechb_day_" + j + "_4") ||
                        (idCelda == "cldFechb_day_" + j + "_5")) {

                        sender._days.all[i].disabled = false;
                        for (var k = 0; k < arrayDiasFeriados.length; k++) {
                            if (sender._months.all[i] != null) {
                                var arreglo = sender._months.all[i].innerText.split("\n");
                                //if (arreglo[1] == DevolverMes(arrayDiasFeriados[k].substring(3, 5))) {
                                    if (Number(sender._days.all[i].innerText) == Number(arrayDiasFeriados[k].substring(0, 2))) {
                                        sender._days.all[i].disabled = true;
                                        sender._days.all[i].innerHTML = "<div>" + sender._days.all[i].innerText + "</div>";
                                        break;
                                    }
                                //}
                            } 
                        }
                    }
                }
            }
        }
    }
}

function DevolverMes(mes) {
    switch (mes) {
        case "01": return "ene"; break;
        case "02": return "feb"; break;
        case "03": return "mar"; break;
        case "04": return "abr"; break;
        case "05": return "may"; break;
        case "06": return "jun"; break;
        case "07": return "jul"; break;
        case "08": return "ago"; break;
        case "09": return "set"; break;
        case "10": return "oct"; break;
        case "11": return "nov"; break;
        case "12": return "dic"; break;
    }
    
}