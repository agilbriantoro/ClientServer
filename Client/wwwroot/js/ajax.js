$.ajax({
    url: "https://db.ygoprodeck.com/api/v7/cardinfo.php?cardset=The%20Pot%20Collection"
}).done((result) => {
    console.log(result.data);
    //let text = "<li>" + result.results[3].name +"</li>"
    //$("#listPoke").html(text)
    let text = "";
    $.each(result.data, function (key, val) {
        if (key <= 19) {
            text += `<tr>
                    <td>${key + 1}</td>
                    <td>${val.name}</td>
                    <td>${val.desc}</td>
                    <td><button class="btn btn-info" onclick="detail('${val.card_images[0].image_url}','${val.name}','${val.type}')" data-bs-toggle="modal" data-bs-target="#modalYuGiOh">Detail</button></td>
                </tr>`;
            //console.log(key);
        }
    })
    $("#tbodyYuGiOh").html(text)

});

/*function detail(stringUrl) {
    $.ajax({
        url: stringUrl
    }).done((result) => {
        console.log(result);
        $("h1#exampleModalLabel.modal-title").innerHTML(result.data.card_images[0].image_url_small);
    });*/

function detail(a, b, c) {
    document.getElementById('update_img').setAttribute('src', a)
    document.getElementById('update_name').innerHTML = b
    document.getElementById('update_type').innerHTML = c
}