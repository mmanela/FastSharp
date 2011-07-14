function cleanup() {
    //System.Debug.outputString("Cleaning up...");

}

function setup() {
    fastSharpGadget = new FastSharpGadget($("#sourceCodeBox"), $("#resultsBox"), $("#runAction"), $("#compileAction"));
    fastSharpGadget.init();


    if (isGadgetMode) {
        System.Gadget.settingsUI = "settings.html";
        System.Gadget.onSettingsClosed = function(event) {
            fastSharpGadget.refreshSettings();
        }

        System.Gadget.onDock = function() {
            $("body").width(300);
            $("body").height(300);
            $("#sourceCodeBox").height(130);
            $("#resultsBox").height(100);
            $("body").css('padding', '0px');
            $("body").css('background-image', "url('../images/background.png')");
        }
        System.Gadget.onUndock = function() {
            $("body").width(500);
            $("body").height(500);
            $("#sourceCodeBox").height(220);
            $("#resultsBox").height(200);
            $("body").css('padding', '5px');
            $("body").css('background-image',"url('../images/backgroundLarge.png')");
        }
        System.Gadget.onShowSettings = function() {

        }
        System.Gadget.visibilityChanged = function() {
            if (System.Gadget.visible) {
            }
        }
    }
}



function FastSharpGadget(codeBox, resultBox, runAction, compileAction) {
    var self = this;
    this.codeBox = codeBox;
    this.resultBox = resultBox;
    this.runAction = runAction;
    this.compileAction = compileAction;

    this.execute = function() {

        var code = self.codeBox.val();
        var result = self.fastSharp.ExecuteSnippet(code);
        self.displayResult(result);

    }

    this.compile = function() {

        var code = self.codeBox.val();
        var result = self.fastSharp.CompileSnippet(code);
        self.displayResult(result);

    }


    this.displayResult = function(result) {

        if (result.HasErrors) {
            self.resultBox.addClass("error");
            self.resultBox.removeClass("success");
        }
        else {
            self.resultBox.removeClass("error");
            self.resultBox.addClass("success");
        }
        self.resultBox.val(result.Output || "");

    }


    this.init = function() {
        self.registerCom();
        self.fastSharp = new ActiveXObject("Jemts.FastSharpCom");

        self.runAction.children().click(self.execute);
        self.compileAction.children().click(self.compile);
    }

    this.registerCom = function() {

        var dllPath;
        if (isGadgetMode)
            dllPath = System.Gadget.path + "/bin/FastSharpLib.dll";
        else
            dllPath = "file:///D:/Dev/FastSharp/FastSharpLib/bin/Debug/FastSharpLib.dll";

        regasm(
          "HKLM", //HKCU
          "Jemts.FastSharpCom",
          "FastSharpLib.FastSharpCom",
          "{FC3F083C-C689-4DE8-8187-C62CBFE67A18}",
          "FastSharpLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=ac56bd59f95f40f3",
          "1.0.0.0",
          dllPath,
          "FastSharpLib.FastSharpResult",
          "{F6D7CA1D-88B3-4303-BD7D-BF9D74B3ECB6}"
          );

        regasm(
          "HKLM", //HKCU
          "Jemts.FastSharpComResult",
          "FastSharpLib.FastSharpComResult",
          "{F6D7CA1D-88B3-4303-BD7D-BF9D74B3ECB6}",
          "FastSharpLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=ac56bd59f95f40f3",
          "1.0.0.0",
          dllPath);

    }

    this.refreshSettings = function() {
    }
}

$(window).load(setup);
$(window).unload(cleanup);