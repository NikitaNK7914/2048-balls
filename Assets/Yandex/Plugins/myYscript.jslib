mergeInto(LibraryManager.library,{
	ShowFullscreenAdv:function(){
		ysdk.adv.showFullscreenAdv({
		callbacks :{
			onClose:function(wasShown){
			
			},
			onError:function(error){
			
			}
		}
	})
	},
	GetLanguage:function(){
	var returnStr = ysdk.environment.i18n.lang;
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
	},
});