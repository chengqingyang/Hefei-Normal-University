var bsYear; 
var bsDate; 
var bsWeek; 
var arrLen=10; //���鳤�� 
var sValue=0; //��������� 
var dayiy=0; //����ڼ��� 
var miy=0; //�·ݵ��±� 
var iyear=0; //��ݱ�� 
var dayim=0; //���µڼ��� 
var spd=86400; //ÿ������� 
var year1999="30;29;29;30;29;29;30;29;30;30;30;29"; //354 
var year2000="30;30;29;29;30;29;29;30;29;30;30;29"; //354 
var year2001="30;30;29;30;29;30;29;29;30;29;30;29;30"; //384 
var year2002="30;30;29;30;29;30;29;29;30;29;30;29"; //354 
var year2003="30;30;29;30;30;29;30;29;29;30;29;30"; //355 
var year2004="29;30;29;30;30;29;30;29;30;29;30;29;30"; //384 
var year2005="29;30;29;30;29;30;30;29;30;29;30;29"; //354 
var year2006="30;29;30;29;30;30;29;29;30;30;29;29;30"; 
var year2007="29;29;30;29;29;30;29;30;30;30;29;30"; //�����ʾ2007������ÿ�µ�������ע�⣬����2006�����������꣬������13���£���2007�겻�����ꡣ
var year2008="30;29;29;30;29;29;30;29;30;30;29;30";

var month1999="����;����;����;����;����;����;����;����;����;ʮ��;ʮһ��;ʮ����" 
var month2001="����;����;����;����;������;����;����;����;����;����;ʮ��;ʮһ��;ʮ����" 
var month2004="����;����;�����;����;����;����;����;����;����;����;ʮ��;ʮһ��;ʮ����" 
var month2006="����;����;����;����;����;����;����;������;����;����;ʮ��;ʮһ��;ʮ����" 
var Dn="��һ;����;����;����;����;����;����;����;����;��ʮ;ʮһ;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;��ʮ;إһ;إ��;إ��;إ��;إ��;إ��;إ��;إ��;إ��;��ʮ"; 

var Ys=new Array(arrLen); 
Ys[0]=919094400;Ys[1]=949680000;Ys[2]=980265600; 
Ys[3]=1013443200;Ys[4]=1044028800;Ys[5]=1074700800; 
Ys[6]=1107878400;Ys[7]=1138464000; 
Ys[8]=1171728000;//��������Ǵ����һ0��00��ʱ��javascript��D.getTime() / 1000��ֵ
//var D=new Date();
//alert(D.getTime() / 1000);
Ys[9]=1202313600;

var Yn=new Array(arrLen); //ũ��������� 
Yn[0]="��î��";Yn[1]="������";Yn[2]="������"; 
Yn[3]="������";Yn[4]="��δ��";Yn[5]="������"; 
Yn[6]="������";Yn[7]="������"; 
Yn[8]="������";
Yn[9]="������";
var D=new Date(); 
var yy=D.getYear(); 
if ( navigator.appName == "Netscape" ) yy+= 1900;  
var mm=D.getMonth()+1; 
var dd=D.getDate(); 
var ww=D.getDay(); 
if (ww==0) ww="<font color=RED>������"; 
if (ww==1) ww="����һ"; 
if (ww==2) ww="���ڶ�"; 
if (ww==3) ww="������"; 
if (ww==4) ww="������"; 
if (ww==5) ww="������"; 
if (ww==6) ww="<font color=RED>������"; 
ww=ww; 
var ss=parseInt(D.getTime() / 1000); 
if (yy<100) yy="19"+yy; 

for (i=0;i<arrLen;i++) 
if (ss>=Ys[i]){ 
iyear=i; 
sValue=ss-Ys[i]; //��������� 
} 
dayiy=parseInt(sValue/spd)+1; //��������� 

var dpm=year1999; 
if (iyear==1) dpm=year2000; 
if (iyear==2) dpm=year2001; 
if (iyear==3) dpm=year2002; 
if (iyear==4) dpm=year2003; 
if (iyear==5) dpm=year2004; 
if (iyear==6) dpm=year2005; 
if (iyear==7) dpm=year2006; 
if (iyear==8) dpm=year2007;
if (iyear==9) dpm=year2008;
dpm=dpm.split(";"); 

var Mn=month1999; 
if (iyear==2) Mn=month2001; 
if (iyear==5) Mn=month2004; 
if (iyear==7) Mn=month2006; 
Mn=Mn.split(";"); 

var Dn="��һ;����;����;����;����;����;����;����;����;��ʮ;ʮһ;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;ʮ��;��ʮ;إһ;إ��;إ��;إ��;إ��;إ��;إ��;إ��;إ��;��ʮ"; 
Dn=Dn.split(";"); 

dayim=dayiy; 

var total=new Array(13); 
total[0]=parseInt(dpm[0]); 
for (i=1;i<dpm.length-1;i++) total[i]=parseInt(dpm[i])+total[i-1]; 
for (i=dpm.length-1;i>0;i--) 
if (dayim>total[i-1]){ 
dayim=dayim-total[i-1]; 
miy=i;
break; 
} 
bsWeek=ww; 
bsDate="<span class=\"t_rq\">"+yy+"</span>��"+"<span class=\"t_rq\">"+mm+"</span>��"; 
bsDate2="<span class=\"t_rq\">"+dd+"</span>��"; 
bsYear="ũ��"+Yn[iyear]; 
bsYear2=Mn[miy]+Dn[dayim-1]; 
if (ss>=Ys[9]||ss<Ys[0]) bsYear=Yn[9]; 


function CAL(){ 
/*document.write("<table border='0' cellspacing='0' width='100' bordercolor='#FFFFFF' height='80' cellpadding='0'"); 
document.write("<tr><td align='center'><b><font color=red>"+bsDate+"</font><br><font face='Arial' size='4' color=#FF8040>"+bsDate2+"</font><br><font color=blue><span style='FONT-SIZE: 9pt'>"); 
document.write(bsWeek+"</span><br>"+"</b><font color=#9B4E00>"); 
document.write(bsYear+bsYear2+"</td></tr></table>");*/ 
document.writeln(" <tr>");
document.writeln("                <td align=\"left\" valign=\"top\" class=\"t_hui\">"+bsDate+bsDate2+"<br>"+bsWeek+"<\/td>");
document.writeln("              <\/tr>");
document.writeln("            <\/table>");


document.writeln("            <table width=\"100\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
document.writeln("              <tr>");
document.writeln("                <td height=\"10\"><\/td>");
document.writeln("              <\/tr>");
document.writeln("            <\/table>");
//document.writeln("            <table width=\"90%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"zi_gao\">");
//document.writeln("              <tr>");
//document.writeln("                <td align=\"left\" valign=\"top\"><strong class=\"t_hui\">ũ������<\/strong><\/td>");
//document.writeln("              <\/tr>");
//document.writeln("            <\/table>");
document.writeln("            <table width=\"90%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"zi_gao\">");
/*document.writeln("              <tr>");
document.writeln("                <td align=\"left\" valign=\"top\" class=\"t_hui\">"+bsYear+bsYear2+"<\/td>");
document.writeln("              <\/tr>")*/
}