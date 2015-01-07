
var array_pictures;
var array_pictures_index;
$(document).keyup(function(e) {

    if (e.keyCode == 27) {
        $('.container_Images').toggle();
    }   // esc
});
$(document).ready(function () {
    
    var x;

    x = $('#PageList').change(ContentChange);
    //x = $('#newcontent')
    //x.toggle();
    x = $('#btSave');
    x.click(addNewContent);

    x = $('.galeria');
    x.click(showGaleria);
    x = $('.arrow-left');
    x.click(previousPicture);
    x = $('.arrow-right');
    x.click(nextPicture);

    //$('#uploadImages').change(function () {
    //    debugger;
    //    var file = document.getElementById('uploadImages').files[0];
    //    var fileName = file.name;
    //    var fd = new FormData();
    //    fd.append("fileData", file);
    //    fd.append("key", '@Model.Id');

    //    var xhr = new XMLHttpRequest();
    //    xhr.upload.addEventListener("progress", function (evt) { UploadProgress(evt); }, false);
    //    xhr.addEventListener("load", function (evt) { UploadComplete(evt); }, false);
    //    xhr.addEventListener("error", function (evt) { UploadFailed(evt); }, false);
    //    xhr.addEventListener("abort", function (evt) { UploadCanceled(evt); }, false);
    //    xhr.open("POST", "/UploadImages", true);
    //    xhr.send(fd);
    //});
});
function previousPicture() {
   
    
    if (array_pictures_index == 0) {
        array_pictures_index = array_pictures.length -1;
    }
    else {
        array_pictures_index--;
    }
 
    var im = $('#currentImage')
        .attr('src', 'data:"image/jpg;base64,' + array_pictures[array_pictures_index]);

}
function nextPicture() {
 

    if (array_pictures_index == array_pictures.length - 1) {
        array_pictures_index = 0;
    }
    else {
        array_pictures_index++;
    }

    var im = $('#currentImage')
        .attr('src', 'data:"image/jpg;base64,' + array_pictures[array_pictures_index]);

}
function showGaleria() {
    
    var x = $(this);
    var id= x.attr('id');
    var IList = $('#list_Ima')
    $.ajax({
        url: "../Content/GetImagesBase64",
        type: "POST",
        dataType: 'json',
        data: { section: id },
        traditional: true,
        success: function (data) {
            array_pictures = data;
            array_pictures_index = 0;
            var im = $('#currentImage')
                    .attr('src', 'data:"image/jpg;base64,' + array_pictures[array_pictures_index])
                $('.container_Images').toggle();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
   
   

}
function deletePicture(id) {
    var x = $(document.getElementById(id));


    $.ajax({
        url: "../Content/DeletePicture",
        type: "POST",
        dataType: 'json',
        data: { id: id },
        traditional: true,
        success: function (data) {
            x.toggle();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}
function ContentChange()
{
    var section = $(this).find('option:selected').val();
    
    $.ajax({
        url: "GetContent",
        type: 'GET',
        dataType: 'json',
        data: { section: section },
        success: function (data) {
            var myObject = data;
            var x = $("#specificcontent");
            x.html(data);
            //x.prepend(data);
            $(':input[value="Edit"]').click(edit);
            $(':input[value="Images"]').click(getImagesbyContent);
            $(':input[value="Delete"]').click(deleteContent);
            $(':input[value="Subir"]').click(increaseOrderContent);
            $(':input[value="Bajar"]').click(decreaseOrderContent);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}
function content(section, title, text) {
    this.Section = section;
    this.Title=title;
    this.Text = text;  
}

function addNewContent() {
    var section = $('#PageList').val();
    var x = $('#nctitle').val();
    var y = $('#nctext').val();
    var addedcontent = new content(section, x, y);
    //var array = [];
    //array.push(newcontent);
    
    $.ajax({
        url: "AddContent",
        type: "POST",
        dataType: 'json',
        data: { newcontent: JSON.stringify(addedcontent) },
        traditional: true,
        success: function (data) {

            var myObject = document.createElement('div');
            myObject.innerHTML = data;

            
     

            var x = $("#contents");
            x.append(myObject);
            $(':input[value="Edit"]').click(edit);
            $(':input[value="Images"]').click(getImagesbyContent);
            $(':input[value="Delete"]').click(deleteContent);
            $(':input[value="Subir"]').click(increaseOrderContent);
            $(':input[value="Bajar"]').click(decreaseOrderContent);
          
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}

function deleteContent() {
    var x = GetParents($(this));
    var div = $(x[0]);
    var id = div.attr('id');
    $.ajax({
        url: "DeleteContent",
        type: "POST",
        dataType: 'json',
        data: { content: id },
        traditional: true,
        success: function (data) {
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}
function decreaseOrderContent() {
    var x = GetParents($(this));
    var div = $(x[0]);
    var id = div.attr('id');
    $.ajax({
        url: "DecreaseOrderContent",
        type: "POST",
        dataType: 'json',
        data: { content: id },
        traditional: true,
        success: function (data) {
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}
function increaseOrderContent() {
    var x = GetParents($(this));
    var div = $(x[0]);
    var id = div.attr('id');
    $.ajax({
        url: "IncreaseOrderContent",
        type: "POST",
        dataType: 'json',
        data: { content: id },
        traditional: true,
        success: function (data) {

            div.toggle();
            $("#Images").html("");



        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
}
function edit() {
    bt = $(this);
    bt.html('Save');
    bt.off();
    bt.click(save);
    var x = GetParents($(this));
    var inputs = $(x[0]).find("input");
    inputs.removeAttr("disabled");
    var btimg = $(x[0]).find(':input[value="Images"]');
    btimg.toggle();
    x = GetParents($(this));
    var div = $(x[0]);
    var id = div.attr('id');
    $("#contentID").val(id);
    


}
function save() {
    bt = $(this);
    bt.html('Editar');
    bt.off();
    bt.click(edit);
    var x = GetParents($(this));
    var div = x.find("div");
     div = div[0];
     div = $(div);
     var id = div.attr('id');
     var btimg = $(x[0]).find(':input[value="Images"]');
     btimg.toggle();
    //for (var i = 0; i < children.length; i++) {
    //    if (children.tagName == 'INPUT') {        
    //        searchEles[i].attr("disabled", "disabled");
            
    //    }
    //}
    var inputs = div.find("input");
    inputs.attr("disabled", "disabled");

    var tl = $(inputs[0]).val();
    var tx = $(inputs[1]).val();
    
    var editedcontent = new content(id, tl, tx);

    $.ajax({
        url: "EditContent",
        type: "POST",
        dataType: 'json',
        data: { editedcontent: JSON.stringify(editedcontent) },
        traditional: true,
        success: function (data) {


           

        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });
    $(".row").toggle();
}


function getImagesbyContent() {

    var midiv = document.getElementById('Images');

    while (midiv.hasChildNodes()) {
        midiv.removeChild(midiv.firstChild);
    }
    $(".row").toggle();
    var x = GetParents($(this));
    //var div = x.find("div");
    // div = div[0];
     var div = $(x[0]);
     var id = div.attr('id');

     $.ajax({
         url: "GetImages",
         type: "POST",
         dataType: 'json',
         data: { section: id },
         traditional: true,
         success: function (data) {
             $("#Images").append(data);



         },
         error: function (xhr, ajaxOptions, thrownError) {
             $("#Content").html("Unexpected error. Please refresh the page to load again");
         }
     });
     $('#Images img').ready(imageResize);

}
function imageResize()
{
    // IMAGE RESIZE
    $('#Images img').each(function () {
        var maxWidth = 120;
        var maxHeight = 120;
        var ratio = 0;
        var width = $(this).width();
        var height = $(this).height();

        if (width > maxWidth) {
            ratio = maxWidth / width;
            $(this).css("width", maxWidth);
            $(this).css("height", height * ratio);
            height = height * ratio;
        }
        var width = $(this).width();
        var height = $(this).height();
        if (height > maxHeight) {
            ratio = maxHeight / height;
            $(this).css("height", maxHeight);
            $(this).css("width", width * ratio);
            width = width * ratio;
        }
    });
    //$("#contentpage img").show();
    // IMAGE RESIZE

}
function uploadpicture() {
    var x = $(this);
     x = GetParents($(this));
    var inputs = x[1];
    var inputsfile = $(inputs).find(".input-files")
    var uploadImages = $(inputsfile[0]);
    //var uploadImages = new FormData($(ufile));
    $.ajax({
        url: "UploadImages",
        type: "POST",
        dataType: 'json',
        data: { contentID: JSON.stringify("hola") },
        traditional: true,
        success: function (data) {
        },
        error: function (xhr, ajaxOptions, thrownError) {
            $("#Content").html("Unexpected error. Please refresh the page to load again");
        }
    });

}

function GetParents(e) {
    return $(e).parents();

}




//------------

function UploadImage() {
    $("#ImgForm").submit();
}

function UploadImage_Complete() {
    //Check to see if this is the first load of the iFrame
    if (isFirstLoad == true) {
        isFirstLoad = false;
        return;
    }

    //Reset the image form so the file won't get uploaded again
    document.getElementById("ImgForm").reset();

    //Grab the content of the textarea we named jsonResult .  This shold be loaded into 
    //the hidden iFrame.
    var newImg = $.parseJSON($("#UploadTarget").contents().find("#jsonResult")[0].innerHTML);

    //If there was an error, display it to the user
    if (newImg.IsValid == false) {
        alert(newImg.Message);
        return;
    }

    //Create a new image and insert it into the Images div.  Just to be fancy, 
    //we're going to use a "FadeIn" effect from jQuery
    var imgDiv = document.getElementById("Images");
    var img = new Image();
    img.attr('src', 'data:"image/jpg;base64,' + newImg.ImagePath);
        

    //Hide the image before adding to the DOM
    $(img).hide();
    imgDiv.appendChild(img);
    //Now fade the image in
    $(img).fadeIn(500, null);
}
//--uload file




function UploadProgress(evt) {
    if (evt.lengthComputable) {
        var percentComplete = Math.round(evt.loaded * 100 / evt.total);
        //$("#uploading").text(percentComplete + "% ");
    }
}

function UploadComplete(evt) {
    //if (evt.target.status == 200)
    //alert(evt.target.responseText);
    //else {
    //   // alert("Error Uploading File");
    //}
}

