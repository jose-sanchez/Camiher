function openTargetBlank(e){
   
   var className = 'external';
   
   if (!e) var e = window.event;
   var clickedObj = e.target ? e.target : e.srcElement;
   
   if(clickedObj.nodeName == 'A' )
    {
      r=new RegExp("(^| )"+className+"($| )");
      if(r.test(clickedObj.className)){
         window.open(clickedObj.href);
         return false;
   
      }
    }
}
   
document.onclick = openTargetBlank;