var isGadgetMode = (window.System !== undefined);

function regasm(root, progId, cls, clsid, assembly, version, codebase, structCls, structClsid) {
  var wshShell;
  wshShell = new ActiveXObject("WScript.Shell"); 

  //wshShell.RegWrite(root + "\\Software\\Classes\\", progId);
  wshShell.RegWrite(root + "\\Software\\Classes\\" + progId + "\\", cls);
  wshShell.RegWrite(root + "\\Software\\Classes\\" + progId + "\\CLSID\\", clsid);
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\", cls); 

  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\", "mscoree.dll");
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\ThreadingModel", "Both");
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\Class", cls);
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\Assembly", assembly);
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\RuntimeVersion", "v2.0.50727");
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\CodeBase", codebase); 

  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\" + version + "\\Class", cls);
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\" + version + "\\Assembly", assembly);
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\" + version + "\\RuntimeVersion", "v2.0.50727");
  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\InprocServer32\\" + version + "\\CodeBase", codebase); 

  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\ProgId\\", progId); 

  wshShell.RegWrite(root + "\\Software\\Classes\\CLSID\\" + clsid + "\\Implemented Categories\\{62C8FE65-4EBB-45E7-B440-6E39B2CDBF29}\\", "");
  
  if(structCls){
  // define struct
    wshShell.RegWrite(root + "\\Software\\Record\\" + structClsid + "\\" + version + "\\Class", structCls);
    wshShell.RegWrite(root + "\\Software\\Record\\" + structClsid + "\\" + version + "\\Assembly", assembly);
    wshShell.RegWrite(root + "\\Software\\Record\\" + structClsid + "\\" + version + "\\RuntimeVersion", "v2.0.50727");
    wshShell.RegWrite(root + "\\Software\\Record\\" + structClsid + "\\" + version + "\\CodeBase",codebase);
    }
}

function saveSetting(theSettingName, aSettingValue) {
    try {
        if (isGadgetMode) {
            // If we are in "Gadget Mode", save off the value using that mechanism
            System.Gadget.Settings.write(theSettingName, aSettingValue);
        }
        else {
            // If we are in "development mode" - use a cookie instead
            writeCookie(theSettingName, aSettingValue);
        }
    }
    catch (objException) {
    }
}


function readSetting(theSettingName) {
    var retVal = "";
    try {
        if (isGadgetMode) {
            retVal = System.Gadget.Settings.read(theSettingName);
        }
        else {
            retVal = readCookie(theSettingName);
        }
    }
    catch (objException) {
        retVal = null;
    }
    return retVal;
}


function writeCookie(theCookieName, aCookieValue) {
    var theCookieExpirationDate = new Date();
    theCookieExpirationDate.setYear(theCookieExpirationDate.getYear() + 1);
    theCookieExpirationDate = theCookieExpirationDate.toGMTString();
    document.cookie = escape(theCookieName) + "=" + escape(aCookieValue) + "; expires=" + theCookieExpirationDate;
}


function readCookie(theCookieName) {
    var aCookieValue = "";
    var theCookies = ("" + document.cookie).split("; ");
    for (var i = 0; i < theCookies.length; i++) {
        if (theCookies[i].indexOf("=") > -1) {
            var aCookieName = theCookies[i].split("=")[0];
            if (aCookieName == theCookieName) {
                aCookieValue = theCookies[i].split("=")[1];
                break;
            }
        }
    }
    return aCookieValue;
}
