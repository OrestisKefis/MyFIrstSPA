//Before Document ready --- START

//Handlers --- START
function OnDeleteForceUserHandler(id, event) {


    var settings = {
        "url": "https://localhost:44369/ForceUserApi/DeleteForceUserById?id=" + id,
        "method": "POST",
        "timeout": 0,
    };

    $.ajax(settings).done(function (forceUser) {

        DeleteDataRow(event);
        ShowAlert("success", "Success", `Force User with id ${id} has been succeefully deleted`)
        AlertTimeout(1000);


    }).fail(function () {
        ShowAlert("danger", "Fail", `Failed to delete Force User with id ${id} ....Server Error...`)
        AlertTimeout(1000);
    });
}


function OnDetailsHandler(id) {

    var settings = {
        "url": "https://localhost:44369/forceuserapi/GetForceUserById?id=" + id,
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (forceUser) {

        FillDetailsWithData(forceUser);

        let userFirstName = forceUser.FirstName;
        let infoUrl = InfoUrl(userFirstName);

        $("#descDet > span > a").attr("href", infoUrl);
        $("#myDetailsModal").modal("show");

    }).fail(function () {
        ShowAlert("danger", "Fail", `Failed to load details of Force User with id ${id} ....Server Error...`)
    });

}
//Handlers --- STOP




//Interaction with elements --- START
function FillDetailsWithData(forceUser) {

    $("#userPhotoDet").attr("src", forceUser.PhotoUrl);
    $("#firstNameDet > span").text(forceUser.FirstName);
    $("#lastNameDet > span").text(forceUser.LastName);
    $("#specialiazationDet > span").text(forceUser.Specialiazation);
    $("#midichloriansDet > span").text(forceUser.Midichlorians);
    $("#sideDet > span").text(forceUser.Side);
    $("#rankDet > span").text(forceUser.Rank);
    $("#deceasedDet > span").text(forceUser.Deceased == true ? "Passed Away" : "Not yet...");
    $("#descDet > p").text(forceUser.Description);
}


function DeleteDataRow(event) {
    $(event).parent().parent().remove();
}


function InfoUrl(userFirstName) {
    let infoUrl = "";

    switch (userFirstName) {
        case "Obi-Wan": infoUrl = "https://starwars.fandom.com/wiki/Obi-Wan_Kenobi"; break;
        case "Minch": infoUrl = "https://starwars.fandom.com/wiki/Minch"; break;
        case "Anakin": infoUrl = "https://starwars.fandom.com/wiki/Anakin_Skywalker"; break;
        case "Luke": infoUrl = "https://starwars.fandom.com/wiki/Luke_Skywalker"; break;
        case "Darth": infoUrl = "https://www.starwars.com/databank/darth-vader"; break;
        case "Sheev": infoUrl = "https://starwars.fandom.com/wiki/Darth_Sidious"; break;
        default: alert("Source of informetion does not exist"); break;
    }

    return infoUrl;
}
//Interaction with elements --- STOP



function AlertTimeout(seconds) {
    let count = 0;



    let timeout = setInterval(function () {
        count += 1;
        console.log(count);

        if (count == 3) {
            $(".close").trigger("click");
            clearInterval(timeout);
        }
    }, seconds);
}



//Alert --- START
function ShowAlert(status, failOrSuccess, message) {
    let template = `
                            <div class="alert alert-${status} alert-dismissible">
                                  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                  <strong>${failOrSuccess}!</strong>${message}.
                            </div>

                            `;

    let element = $(template);
    $("#jediTableContainer").append(element);

}
//Alert --- STOP
//Before Document ready --- STOP




//Document ready
$(document).ready(function () {

    //On index load
    OnLoadForceUserDataHandler();


    //Element variables
    let jediTableShow = $("#jediTableShow");
    let sithTableShow = $("#sithTableShow");
    let jediTable = $("#jediTable");
    let sithTable = $("#sithTable");
    let jediTableContainer = $("#jediTableContainer");
    let sithTableContainer = $("#sithTableContainer");
    let backBtns = $(".backBtns");
    let createJediBtn = $("#createJediBtn");
    let createSithBtn = $("#createSithBtn");
    let createBtn = $("#createBtn");





    //Events --- START
    jediTableShow.on("click", function () {
        HideJediData(false);
        HideTableInteractiveImages(true);
    })

    sithTableShow.on("click", function () {
        HideSithData(false);
        HideTableInteractiveImages(true);
    })

    backBtns.on("click", ShowMain)

    createJediBtn.on('click', function () {
        CustomizeRandAndSideSelections("Jedi");
    })

    createSithBtn.on('click', function () {
        CustomizeRandAndSideSelections("Sith");
    })

    createBtn.on("click", function () {
        OnCreateForceUserHandler();
    })
    //Events --- STOP






    //Handlers -- START
    function OnLoadForceUserDataHandler() {

        var settings = {
            "url": "https://localhost:44369/forceuserapi/getallforceusers",
            "method": "GET",
            "timeout": 0,
        };

        $.ajax(settings).done(function (forceUsers) {

            forceUsers.forEach(AppendDataToRightTable)

        }).fail(function () {
            ShowAlert("danger", 'Fail', "Failed to load force users....Server error...");
            AlertTimeout(1000);
        });
    }


    function OnCreateForceUserHandler() {

        let firstName = $("#FirstName").val();
        let lastName = $("#LastName").val();
        let specialiazation = $("#Specialiazation").val();
        let midichlorians = $("#Midichlorians").val();
        let photoUrl = $("#PhotoUrl").val();
        let side = $("#Side").val();
        let rank = $("#Rank").val();
        let deceased = $("#Deceased").val();

        let forceUser = {
            FirstName: firstName,
            LastName: lastName,
            PhotoUrl: photoUrl,
            Specialiazation: specialiazation,
            Midichlorians: midichlorians,
            Side: side,
            Rank: rank,
            Deceased: deceased
        }

        let stringifiedForceUser = JSON.stringify(forceUser);
        

       
        var settings = {
            "url": "https://localhost:44369/forceuserapi/InsertForceUser",
            "method": "POST",
            "timeout": 0,
            "headers": {
                "Content-Type": "application/json"
            },
            "data": stringifiedForceUser
        };

        $.ajax(settings).done(function (response) {

            $("#forceUserCreateForm")[0].reset();
            location.reload();
            ShowAlert("success", "Success", `Force User with name ${firstName} has been successfully created`)


        }).fail(function () {
            ShowAlert("danger", "Fail", "Undable to create Force User");
        });
    }
    //Handlers -- END





    //Append Templates ----- START
    function AppendDataToRightTable(user) {

        if (user.Side == "Light") {

            jediTable.children("tbody").append(TableTemplate(user, "Blue"));
        }
        else {
            sithTable.children("tbody").append(TableTemplate(user, "Red"))
        }
    }


    function AppendRankAndSideTemplates(sideTemplate, rankTemplate) {

        let rankElement = $(rankTemplate);
        let sideElement = $(sideTemplate);

        $("#Side").append(sideElement);
        $("#Rank").append(rankElement);
    }
    //Append Templates ----- STOP



    function ClearRankAndSideTemplates() {
        $("#Side").html("");
        $("#Rank").html("");
    }



    //Templates --- START
    function TableTemplate(user, color) {
        let template = `
                                                            <tr id="row${user.ForceUserId}" class="zoomWithoutBlur hover${color}" title="${user.ForceUserId}">
                                                                <td>
                                                                    <img class="forceUserPics" src="${user.PhotoUrl}" alt="Force User Photo" />
                                                                </td>
                                                                <td>${user.FirstName}</td>
                                                                <td>${user.LastName}</td>
                                                                <td>${user.Specialiazation}</td>
                                                                <td>${user.Midichlorians}</td>
                                                                <td>${user.Side}</td>
                                                                <td>${user.Rank}</td>
                                                                <td>${user.Deceased == true ? "Passed Away" : "Not yet...."}</td>
                                                                <td>
                                                                     <button id="detailsBtn${user.ForceUserId}" onclick="OnDetailsHandler(${user.ForceUserId})" class="btn btn-primary">Details</button>
                                                                     <button class="btn btn-success">Edit</button>
                                                                     <button id="deleteBtn${user.ForceUserId}" onclick="OnDeleteForceUserHandler(${user.ForceUserId}, this)" class="btn btn-danger deleteForceUser">Delete</button>
                                                                </td>
                                                            </tr>

                                                        `;

        return template;
    }



    function RankOptionTemplate(user) {

        let rankTemplate = `<option>Gray Jedi</option>`;

        if (user == "Jedi") {

            rankTemplate = `
                            <option>Youngling</option>
                            <option>Padawan</option>
                            <option>Jedi Knight</option>
                            <option>Jedi Master</option>
                            <option>Jedi Grand Master</option>

                            `;
        }
        else if(user == "Sith"){

            rankTemplate = `
                            <option>Sith alchemist</option>
                            <option>Sith assassin</option>
                            <option>Sith battlelord</option>
                            <option>Sith cultist</option>
                            <option>Supreme Commander</option>
                            <option>Sith Emperor</option>

                            `;
        }

        return rankTemplate;

    }


    function SideOptionTemplate(user) {

        let sideTemplate = `<option>In Between</option>`;

        if (user == "Jedi") {
            sideTemplate = `
                                <option>Light</option>
                            `;
        }
        else if (user == "Sith") {
            sideTemplate = `
                                <option>Dark</option>
                            `;
        }

        return sideTemplate;

    }
    //Templates --- END





    //Show-Hide Elements ---- START
    function ShowMain() {
        HideJediData(true);
        HideSithData(true);
        HideTableInteractiveImages(false);
    }

    function HideJediData(hide) {
        jediTableContainer.attr("hidden", hide);
    }

    function HideSithData(hide) {
        sithTableContainer.attr("hidden", hide);
    }

    function HideTableInteractiveImages(hide) {
        jediTableShow.attr("hidden", hide);
        sithTableShow.attr("hidden", hide);
    }

    function ShowCreateModal() {
        $("#myCreateModal").modal("show");
    }
    //Show Hide Elements ---- END



    function CustomizeRandAndSideSelections(forceUser) {

        let sideTemplate = SideOptionTemplate(forceUser);
        let rankTemplate = RankOptionTemplate(forceUser);

        ClearRankAndSideTemplates();
        AppendRankAndSideTemplates(sideTemplate, rankTemplate)
        ShowCreateModal();
    }

})

