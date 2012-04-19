var selectedPrincipalTab = 0;
var entity = 'principal';
/***********************************************
* Common functions to be implemented across CMS
************************************************/
function ShowDialog() {
    HideLoadingPanel();
    $('#dlgAddEdit').dialog('open');
}

function LoadPartialView() {
    //ClearInstallItemDetail();
    $('#divInstallerItemDetail').hide();

    //ClearInstallProcessUserDetail();
    $('#divInstallerProcessUserDetail').hide();
}

function GetDetail(detailId) {
    EditDetail(detailId);
}

function GetModuleDetail(detailId) {
    EditDetail(detailId);
    $('#dlgModuleAddEdit').dialog('open')
}

function GetUserDetail(detailId) {
    EditUserDetail(detailId);
    $('#dlgUserAddEdit').dialog('open')
}

function GetItemDetail(detailId) {
    EditItemDetail(detailId);
    $('#dlgItemAddEdit').dialog('open')
}

function EditDetail(detailId) {
    $("#hdnId").val(detailId);
    $("#btnEdit").click();
}

function EditItemDetail(detailId) {
    $("#hdnItemId").val(detailId);
    $("#btnItemEdit").submit();
}

function EditUserDetail(detailId) {
    $("#hdnUserId").val(detailId);
    $("#btnUserEdit").submit();
}

function NewDetail() {
    //alert(2);
    AddNewDetail();
}

//function Allocate(attendeeId) {
//    AllocateNewAttendee(attendeeId);
//}

function NewIntDetail() {
    AddNewIntDetail();
}

function NewInstallItemDetail() {
    AddNewItemDetail();
    $('#dlgItemAddEdit').dialog('open')
}

function NewInstallerProcessUserDetail() {
    AddNewUserDetail();
    $('#dlgUserAddEdit').dialog('open')
}

function NewTemplateDetail() {
    $("#btnNewTemplateEdit").click();
    $('#dlgNewProcessTemplate').dialog('open')
}

function ConvertTemplateIntoInstall() {
    $("#btnTemplateConvert").click();
    $('#dlgTemplateSelect').dialog('open');
}

var id;
var moduleId;
var subeventid;
var groupid;

function ShowConfirmation(_id, name) {
    id = _id;
    $('#spName').text(name);
    $('#dlgConfirm').dialog("open");
}

function ShowDeAllocateConfirmation(_id, _eventId, _groupid, name) {
    id = _id;
    subeventid = _eventId;
    groupid = _groupid;

    $('#spName').text(name);
    $('#dlgConfirm').dialog("open");
}

function ShowAllocateConfirmation(_id, name) {
    id = _id;
    $('#spAttendeeName').text(name);
    $('#dlgConfirmAllocate').dialog("open");

    LoadNewAllocateDetails(id);
}

function ShowAllocateGroupConfirmation(_id, _eventId, _groupid, name) {
    id = _id;
    subeventid = _eventId;
    groupid = _groupid;

    $('#spAttendeeName').text(name);
    $('#dlgConfirmAllocate').dialog("open");

    LoadExistingAllocatedAttendee(id, _eventId, groupid);
}

function ShowPasswordConfirmation(_id, name) {
    id = _id;    
    $('#spPasswordName').text(name);
    $('#dlgPasswordConfirm').dialog("open");    
}

function ShowItemConfirmation(_id, name) {
    id = _id;
    $('#spItemName').text(name);
    $('#dlgItemConfirm').dialog("open");
}

function ShowUserConfirmation(_id, name) {
    id = _id;
    $('#spUserName').text(name);
    $('#dlgUserConfirm').dialog("open");
}

function ShowModuleConfirmation(_userGroupId,_moduleId, name) {
    id = _userGroupId;
    moduleId = _moduleId;
    $('#spModuleName').text(name);
    $('#dlgModuleConfirm').dialog("open");
}

function RefreshAndCloseDialog(urlAction) {
    UrlRefreshGrid(urlAction, "ResultsGrid");
    $('#dlgAddEdit').dialog("close");
}

function RefreshModulesAndCloseDialog(urlAction) {
    RefreshGrid(urlAction, "ResultsModuleGrid");
    $('#dlgModuleAdd').dialog("close");
}

function RefreshItemsAndCloseDialog(urlAction, processId) {
    RefreshGridWithProcessId(urlAction, "ResultsItemGrid", processId);
    $('#dlgItemAddEdit').dialog("close");
}

function RefreshUsersAndCloseDialog(urlAction, processId) {
    RefreshGridWithProcessId(urlAction, "ResultsUserGrid", processId);
    $('#dlgUserAddEdit').dialog("close");
}

function RefreshTemplatesAndCloseDialog(urlAction) {
    RefreshGrid(urlAction, "ResultsGrid");
    $('#dlgNewProcessTemplate').dialog("close");
}

function RefreshGridWithProcessId(urlAction, gridName, processId) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: 'currentProcessId=' + processId,
        success: function (data, textStatus, XMLHttpRequest) {
            if (data.HasErrors == false) {
                $("#" + gridName).replaceWith(data.Html);
            }
        }
    });
} 

function RefreshGrid(urlAction, gridName) 
{
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            if (data.HasErrors == false) {
                $("#" + gridName).replaceWith(data.Html);
                DoLoadAjax();
            }
        }
    });
}

function DoLoadAjax()
{ }

function AllocateNewAttendee(attendeeId) {
    $("#btnAllocateNewAttendee").click();
}

function AddNewDetail() {
    //$("#btnEdit").click();
    $("#hdnId").val("00000000-0000-0000-0000-000000000000");
    //$("#ajaxLoadingForm").submit();
    $("#btnEdit").click();
}

function AddNewIntDetail() {
    //$("#btnEdit").click();
    $("#hdnId").val("0");
    //$("#ajaxLoadingForm").submit();
    $("#btnEdit").click();
}

function AddNewItemDetail() {
    //$("#btnEdit").click();
    $("#hdnItemId").val("00000000-0000-0000-0000-000000000000");
    //$("#ajaxLoadingForm").submit();
    $("#btnItemEdit").submit();
}

function AddNewUserDetail() {
    //$("#btnEdit").click();
    $("#hdnUserId").val("00000000-0000-0000-0000-000000000000");
    //$("#ajaxLoadingForm").submit();
    $("#btnUserEdit").click();
}

function AddIntNewDetail() {
    //$("#btnEdit").click();
    $("#hdnId").val("0");
    //$("#ajaxLoadingForm").submit();
    $("#btnEdit").click();
}

function DoConfirmationPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            UrlRefreshGrid();
            $('#dlgConfirm').dialog("close");
        }
    });
}

function DoConfirmationSAPSyncPost(urlAction, message) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            if (data.HasErrors == false) {
                ShowSuccessfulMessage(message);
            }
            else {
                ShowErrorMessage(data.Message);
            }
        }
    });
}

function DoConfirmationLocationUpdatePost(urlAction, message) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            if (data.HasErrors == false) {
                ShowSuccessfulMessage(message);
            }
            else {
                ShowErrorMessage(data.Message);
            }
        }
    });
}

function DoAllocateSubeventConfirmationPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            if (data.HasErrors == true) {
                $('#divAttendeeAllocate').html(data.Html);
                alert(data.Html);
            }
            else {
                $('#dlgConfirmAllocate').dialog("close");
                $('#dlgAddEdit').dialog("close");
                $('#Notice').html("Your allocations were successfully saved.");
            }
        }
    });
}

function ShowAllocatedAttendeePost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            $('#divAttendeeAllocate').html(data.Html);
        }
    });
}

function ShowNewAllocateDetailPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            $('#divAttendeeAllocate').html(data.Html);
        }
    });
}

function DoPasswordPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            $('#dlgPasswordConfirm').dialog("close")
        }
    });
}

function DoItemConfirmationPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            UrlRefreshItemGrid();
            $('#dlgItemConfirm').dialog("close")
        }
    });
}

function DoUserConfirmationPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            UrlRefreshUserGrid();
            $('#dlgUserConfirm').dialog("close")
        }
    });
}

function DoModuleConfirmationPost(urlAction) {
    $.ajax({
        type: 'POST',
        url: urlAction,
        data: '',
        success: function (data, textStatus, XMLHttpRequest) {
            UrlRefreshModuleGrid();
            $('#dlgModuleConfirm').dialog("close")
        }
    });
}

function LoadDialogBoxes(editWidth, confirmWidth) {
    $('#dlgAddEdit').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Finish": function () {
                $('#btnFinish').click();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgConfirm').dialog({
        autoOpen: false,
        width: confirmWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgConfirmAllocate').dialog({
        autoOpen: false,
        width: confirmWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Save": function () {
                DoAllocateConfirmation();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadPasswordConfirmationDialog(editWidth) {
    $('#dlgPasswordConfirm').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoPasswordConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadItemBoxes(editWidth, confirmWidth) {
    $('#dlgItemAddEdit').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgItemConfirm').dialog({
        autoOpen: false,
        width: confirmWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoItemConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadUserBoxes(editWidth, confirmWidth) {
    $('#dlgUserAddEdit').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Add": function(){
                $('#btnUserAdd').click();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgUserConfirm').dialog({
        autoOpen: false,
        width: confirmWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoUserConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadTemplateBoxes(editWidth) {
    $('#dlgNewProcessTemplate').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgUserConfirm').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoUserConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadModuleBoxes(editWidth) {
    $('#dlgModuleAdd').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Add": function() {
                $('#btnAddModuleSelect').submit();
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#dlgModuleAddEdit').dialog({
        autoOpen: false,
        width: 550,
        modal: true,
        resizable: false,
        buttons: {
            "Close": function () {
                $(this).dialog("close");
            }
        }
    });
    
    $('#dlgModuleConfirm').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Yes": function () {
                DoModuleConfirmation();
            },
            "No": function () {
                $(this).dialog("close");
            }
        }
    });
}

function LoadTemplateSelectBoxes(editWidth) {
    $('#dlgTemplateSelect').dialog({
        autoOpen: false,
        width: editWidth,
        modal: true,
        resizable: false,
        buttons: {
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });
}

function DisplayInstallerItemInputs(stepType) {

    if (stepType == "Select") {
        $("#divItemContent").hide();
    }
    else {
        $("#divItemContent").show();

        if (stepType == "File") {
            $("#pFileName").show();
            $("#pFileSize").show();
            $("#pFolderName").show();
            $("#pFolderStatus").show();
            $("#pBackupFileName").show();
            $("#pBackupFolderName").show();
            $("#pRegistryKey").hide();
            $("#pRegistryType").hide();
            $("#pRegistryValue").hide();
            $("#pCommand").hide();
            $("#pArgument").hide();
            $("#pSqlScript").hide();
            $("#uploadifyUploader").show();
        }
        else if (stepType == "Folder") {
            $("#pFileName").hide();
            $("#pFileSize").hide();
            $("#pFolderName").show();
            $("#pFolderStatus").show();
            $("#pBackupFileName").hide();
            $("#pBackupFolderName").hide();
            $("#pRegistryKey").hide();
            $("#pRegistryType").hide();
            $("#pRegistryValue").hide();
            $("#pCommand").hide();
            $("#pArgument").hide();
            //$("#pSqlScript").hide();
            $("#uploadifyUploader").hide();
        }
        else if (stepType == "Delete") {
            $("#pFileName").show();
            $("#pFileSize").hide();
            $("#pFolderName").show();
            $("#pFolderStatus").show();
            $("#pBackupFileName").show();
            $("#pBackupFolderName").show();
            $("#pRegistryKey").hide();
            $("#pRegistryType").hide();
            $("#pRegistryValue").hide();
            $("#pCommand").hide();
            $("#pArgument").hide();
            $("#pSqlScript").hide();
            $("#uploadifyUploader").hide();
        }
        else if (stepType == "Run") {
            $("#pFileName").hide();
            $("#pFileSize").hide();
            $("#pFolderName").hide();
            $("#pFolderStatus").hide();
            $("#pBackupFileName").hide();
            $("#pBackupFolderName").hide();
            $("#pRegistryKey").hide();
            $("#pRegistryType").hide();
            $("#pRegistryValue").hide();
            $("#pCommand").show();
            $("#pArgument").show();
            $("#pSqlScript").hide();
            $("#uploadifyUploader").hide();
        }
        else if (stepType == "Database") {
            $("#pFileName").hide();
            $("#pFileSize").hide();
            $("#pFolderName").hide();
            $("#pFolderStatus").hide();
            $("#pBackupFileName").hide();
            $("#pBackupFolderName").hide();
            $("#pRegistryKey").hide();
            $("#pRegistryType").hide();
            $("#pRegistryValue").hide();
            $("#pCommand").hide();
            $("#pArgument").hide();
            $("#pSqlScript").show();
            $("#uploadifyUploader").hide();
        }
        else if (stepType == "Registry") {
            $("#pFileName").hide();
            $("#pFileSize").hide();
            $("#pFolderName").hide();
            $("#pFolderStatus").hide();
            $("#pBackupFileName").hide();
            $("#pBackupFolderName").hide();
            $("#pRegistryKey").show();
            $("#pRegistryType").show();
            $("#pRegistryValue").show();
            $("#pCommand").hide();
            $("#pArgument").hide();
            $("#pSqlScript").hide();
            $("#uploadifyUploader").hide();
        }
    }
}

function InstallProcessDetailNext() {
    LoadItemBoxes(400, 400);

    $('#divInstallerProcessDetail').hide();
    $('#divInstallerItemDetail').show();
    $('#divInstallerProcessUserDetail').hide();

}

function InstallItemDetailNext() {
    $('#divInstallerProcessDetail').hide();
    $('#divInstallerItemDetail').hide();
    $('#divInstallerProcessUserDetail').show();
}

function InstallItemDetailBack() {
    $('#divInstallerProcessDetail').show();
    $('#divInstallerItemDetail').hide();
    $('#divInstallerProcessUserDetail').hide();
}

function InstallProcessUserDetailBack() {
    $('#divInstallerProcessDetail').hide();
    $('#divInstallerItemDetail').show();
    $('#divInstallerProcessUserDetail').hide();

}

function DoValidation(formName) {
    var form = $('#' + formName);
    var context = form[0].MvcValidationFormContext;

    if (form[0]['__MVC_FormValidation']) {
        errors = form[0]['__MVC_FormValidation'].validate("submit");
    }

    if (!form[0]['__MVC_FormValidation'] || errors.length == 0) {
        return true;
    }
}

function InitUploadify() {
    $("#uploadify").uploadify({
        'uploader': '/Content/Flash/uploadify.swf',
        'script': '/Installer/UploadFile',
        'expressInstall': '/Content/Flash/expressInstall.swf',
        'cancelImg': '/Content/Design/cancel.png',
        'folder': '/Content/Uploads',
        'queueID': 'fileQueue',
        'auto': true,
        'multi': false,
        'fileDesc': 'Install Item File',
        'fileExt': '*.*',
        'queueSizeLimit': 90,
        'sizeLimit': 4000000,
        'buttonText': 'Install file',
        'onComplete': function (event, ID, fileObj, response, data) {
            $('#FileName').val(fileObj.name);
            $('#FileSize').val(fileObj.size);
        }
    });
}

function SelectModuleToAdd() {
    $("#btnModuleSelect").submit();
    $('#dlgModuleAdd').dialog("open");
}

function SuccessfulLoad(ajaxContext) {
    Sys.Mvc.FormContext.OnSuccessEnableClientValidation(ajaxContext);
}