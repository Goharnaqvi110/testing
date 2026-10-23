$(document).ready(function () {
    let vehiclecount = document.querySelectorAll('div.avc').length;
    var vcount = vehiclecount + 1;
    var vIndex = vehiclecount;
    $('#addVehicle').click(function (e) {

        if (vcount <= 4) {
            vehiclecount = document.querySelectorAll('div.avc').length;
            vcount = vehiclecount + 1;
            vIndex = vehiclecount;
            //console.log(vcount);
            var newVehicle = '<div id=D' + vcount + ' class="v"><strong class="vv">Vehicle-' + vcount + '</strong><hr>';
            var html = newVehicle + '<div class="avc row">';
            html = html + '<div class="col-md-3">';
            html = html + '<select required name=' + 'ApplicantVehicles[' + vIndex + '].Type asp-for=@Model.ApplicantVehicles[' + vIndex + '].Type class="nice-select w-100">';
            html = html + '<option selected value="">--Select Type of Vehicle--</option>';
            html = html + '<option value="Other">Other</option>';
            html = html + '<option value="Car">Car</option>';
            html = html + '<option value="Truck">Truck</option>';
            html = html + '<option value="Caravan">Caravan</option>';
            html = html + '<option value="Motorbike">Motorbike</option>';
            html = html + '<option value="Boat">Boat</option>';
            html = html + '</select>';
            html = html + '<span data-valmsg-for=ApplicantVehicles[' + vIndex + '].Type data-valmsg-replace="true" class="text-danger"></span>';
            html = html + '</div>';
            html = html + '<div class="col-md-3">';
            html = html + '<input required name=' + 'ApplicantVehicles[' + vIndex + '].Registration  type = "text" asp-for=@Model.ApplicantVehicles[' + vIndex + '].Registration placeholder = "Registration" class="form-control" />';
            html = html + '<span data-valmsg-for=ApplicantVehicles[' + vIndex + '].Registration data-valmsg-replace="true" class="text-danger"></span>';
            html = html + '</div>';
            html = html + '<div class="col-md-3">';
            html = html + '<input required name=' + 'ApplicantVehicles[' + vIndex + '].Make type="text" asp-for=@Model.ApplicantVehicles[' + vIndex + '].Make placeholder="Make" class="form-control"/>';
            html = html + '<span data-valmsg-for=ApplicantVehicles[' + vIndex + '].Make data-valmsg-replace="true" class="text-danger"></span>';
            html = html + '</div>';
            html = html + '<div class="col-md-3">';
            html = html + '<input required name=' + 'ApplicantVehicles[' + vIndex + '].Model type="text" asp-for=@Model.ApplicantVehicles[' + vIndex + '].Model placeholder="Model" class="form-control" />';
            html = html + '<span data-valmsg-for=ApplicantVehicles[' + vIndex + '].Model data-valmsg-replace="true" class="text-danger"></span>';
            html = html + '</div>';
            //html = html + '</div>';
            html = html + '<div class="btn-group m-1">';
            html = html + '<input data-val="true" class="form-check-input" type="checkbox"';
            html = html + 'name=ApplicantVehicles[' + vIndex + '].NeedParking ';
            html = html + 'value="true"/>';
            /*html = html + '<div class="col-md-12">';*/
            html = html + '<span class="m-1">Will you be parking the motor vehicle on the property?</span>';
            /*html = html + '</div>';*/
            html = html + '</div>';
            html = html + '</div>';
            html = html + '<div class="row">';
            html = html + '<div class="col-md-12 text-end">';
            html = html + '<button class="btn btn-danger mb-2 delete"><i class="bi bi-trash"></i> Remove</button>';
            html = html + '</div><hr>';
            $('#dvappendVehicles').append(html);
            ++vcount;
            ++vIndex;
            $('.tab-content').css('height', '+=' + 200);
        }
        else {
            var totalveh = vcount - 1;
            e.preventDefault();
            Swal.fire({
                position: 'top-end',
                icon: 'error',
                title: 'You can not add more than ' + totalveh + ' vehicles',
                showConfirmButton: false,
                timer: 3000
            })
        }

        return false;
    });
    $('#dvappendVehicles').on('click', '.delete', function () {
        $(this).closest('.v').remove();
        $('.tab-content').css('height', '-=' + 200);
        vehiclecount = document.querySelectorAll('div.avc').length;
        vcount = vehiclecount + 1;
        vIndex = vehiclecount;
        $('.v').each(function (index, elem) {
            var id = 'v' + ++index;
            $(this).attr('id', id);
        });
        // Get rows with class 'avc'. UI for each vehicle is rapped inside div with psudo class avc
        
        $('.avc').each(function (index, rowElement) {
            $(rowElement).find('select,input,span').each(function (i, elem) {
                if (elem.nodeName === 'INPUT' || elem.nodeName === 'SELECT') {
                    //updateAttributes(elem, index);
                    var p1 = elem.name.split("[");
                    // split second element of p1 array to remove old index e.g.[0]
                    var p2 = p1[1].split(".");
                    //form updated name of control, p2[1] contains part e.g. Registration
                    name = p1[0] + "[" + index + "]." + p2[1];
                    var id = p1[0] + "_" + index + "_" + p2[1];
                    $(elem).attr('name', name);
                    $(elem).attr('asp-for', "@Model" + name);
                    $(elem).attr('id', id);
                } else if (elem.nodeName === 'SPAN') {
                    //updateValidationAttributes(elem, index);
                    var attr = elem.attributes;
                    var setname;
                    var data_valmsge_xists = attr['data-valmsg-for'];
                    if (data_valmsge_xists) {
                        setname = attr['data-valmsg-for'].value;                    
                    //debugger;
                    //console.log(name);
                    //Split name of each element i.e. ApplicantVehicles[0].Registration
                    var part1 = setname.split("[");
                    // split second element of p1 array to remove old index e.g.[0]
                    var part2 = part1[1].split(".");
                    //form updated name of control, p2[1] contains part e.g. Registration
                    var Newname = part1[0] + "[" + index + "]." + part2[1];
                    var id = part1[0] + "_" + index + "_" + part2[1];
                    // $(elem).attr('name', Newname);
                    //$(elem).attr('id', id);
                    $(elem).attr('data-valmsg-for', Newname);
                    //console.log(Newname);
                    //console.log(id);
                    }
                }
            });
        });

        var vehno = 2;
        //Get all divs with class v that contain <strong> used for vehicle no
        $('.v').children('strong').each(function (index, elem) {
            if (index == 0) {
                elem.innerHTML = 'Primary Vehicle';
                ++index;
            }
            else {
                elem.innerHTML = 'Vehicle-' + ++index;
                //vcount = index + 1;
            }
            vcount = index + 1;
            vIndex = index;
        });
        return false;
    });
});