
function setup() {

    loadAndApplySettingsToPage();

    // If we are in "Gadget Mode" then hook the OnSettingsClosing event 
    // (triggered when user clicks "OK" from the Settings Pane) to our 
    // custom "Save Settings" function
    if (isGadgetMode) {
        System.Gadget.onSettingsClosing = function(event) {
            if (event.closeAction == event.Action.commit) {
                extractAndSaveSettingsFromPage();
            }
        }
    }
}


function loadAndApplySettingsToPage() {
}

function extractAndSaveSettingsFromPage() {

}

