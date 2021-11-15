function gridOnMouseOver(row)
{
    row.style.backgroundColor = '#ffffe1';
}

function gridOnMouseOut(row)
{
    row.style.backgroundColor ='#F7F6F3';
}

function gridOnMouseOutAlternate(row)
{
    row.style.backgroundColor ='White';
}

function checkoncheck(dgrow)
{
    var mycheck = dgrow.getElementsByTagName("input")[0];
	if(mycheck.checked==true)
		mycheck.checked=false;
	else
		mycheck.checked=true;   
}

function selectAll()
{        
	   var mygrid= document.getElementById("GridDiv");
       var arrmyinput = mygrid.getElementsByTagName("input");                                      
       var value=document.forms[0].select.checked;
       for(var i=0;i<arrmyinput.length;i++)
          arrmyinput.item(i).checked=value;
         
}
function PopUpWindow_Select(SpanName,ID)
{
    var Pagespan=window.opener.document.getElementById(SpanName);
    var txtID=Pagespan.getElementsByTagName("input");
    txtID[0].value=ID;
    window.close();
}

function PopUpWindow_MultiNewsSelect(SpanName, ID) {
    var Pagespan = window.opener.document.getElementById(SpanName);
    var txtID = Pagespan.getElementsByTagName("input");
    if (txtID[0].value == '' || txtID[0].value == '0') {
        txtID[0].value = ID;
    }
    else {
        if (txtID[0].value != ID) {
            if (txtID[0].value.indexOf(ID + '-') == -1 && txtID[0].value.indexOf('-' + ID) == -1) {
                txtID[0].value = txtID[0].value + "-" + ID;
            }
        }
    }
}

function PopUpWindow_Moalef_Nasher_Select(SpanName,ID,MoalefName)
{
    var Pagespan=window.opener.document.getElementById(SpanName);
    var txtID=Pagespan.getElementsByTagName("input");
    txtID[0].value=MoalefName;
    txtID[0].readonly=true;
    txtID[2].value=ID;   
    window.close();
}

function PopUpWindow_AdvertismentSelect(SpanName,ID)
{
    var Pagespan=window.opener.document.getElementById(SpanName);
    var txtID=Pagespan.getElementsByTagName("input");
    txtID[0].value=txtID[0].value+"-"+ID;    
}

function PopUpWindow_AdvertismentClose()
{
    window.close();
}

function PopUpWindow_AdvertismentResetText(TempSpanName)
{
    var TempPageSpan=window.opener.document.getElementById(TempSpanName);
    var TemptxtID=TempPageSpan.getElementsByTagName("input");
    TemptxtID[0].value="";    
   
}

function PopUpWindow_Open(url)
{
    window.open('?'+url,'_blank','location=0,toolbar=0,statusbar=0,menubar=0,resizable=0,scrollbars=1,width=850,height=600');
}

function PopUpWindow_Open_cus(url, width, height) {
    var left = (screen.width / 2) - (width / 2);
    var top = (screen.height / 2) - (height / 2);
    window.open('?' + url, '_blank', 'location=0,toolbar=0,statusbar=0,menubar=0,resizable=0,scrollbars=1,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left + '');
}