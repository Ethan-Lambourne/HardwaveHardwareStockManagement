function changeAddItemForm() {
    var choiceIndex = document.getElementById("selectType").selectedIndex;

    switch (document.getElementsByTagName("option")[choiceIndex].value) {

        case "case":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("formFactorInput").className = "col-sm-4 m-3";
            document.getElementById("createCase").className = "btn btn-success";
            document.getElementById("formFactorInput").childNodes[3].setAttribute("required", "");
            break;

        case "cpu":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("coresInput").className = "col-sm-4 m-3";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3";
            document.getElementById("socketInput").className = "col-sm-4 m-3";
            document.getElementById("createCPU").className = "btn btn-success";
            document.getElementById("coresInput").childNodes[3].setAttribute("required", "");
            document.getElementById("clockSpeedInput").childNodes[3].setAttribute("required", "");
            document.getElementById("socketInput").childNodes[3].setAttribute("required", "");
            break;

        case "graphics card":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("vramInput").className = "col-sm-4 m-3";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3";
            document.getElementById("createGraphicsCard").className = "btn btn-success";
            document.getElementById("vramInput").childNodes[3].setAttribute("required", "");
            document.getElementById("cudaCoreInput").childNodes[3].setAttribute("required", "");
            break;

        case "laptop":
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("screenSizeInput").className = "col-sm-4 m-3";
            document.getElementById("ramInput").className = "col-sm-4 m-3";
            document.getElementById("storageInput").className = "col-sm-4 m-3";
            document.getElementById("createLaptop").className = "btn btn-success";
            document.getElementById("screenSizeInput").childNodes[3].setAttribute("required", "");
            document.getElementById("ramInput").childNodes[3].setAttribute("required", "");
            document.getElementById("storageInput").childNodes[3].setAttribute("required", "");
            break;

        case "memory":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3";
            document.getElementById("createMemory").className = "btn btn-success";
            document.getElementById("memoryTypeInput").childNodes[3].setAttribute("required", "");
            document.getElementById("memorySizeInput").childNodes[3].setAttribute("required", "");
            document.getElementById("memorySpeedInput").childNodes[3].setAttribute("required", "");
            break;

        case "monitor":
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("screenSizeInput").className = "col-sm-4 m-3";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3";
            document.getElementById("createMonitor").className = "btn btn-success";
            document.getElementById("screenSizeInput").childNodes[3].setAttribute("required", "");
            document.getElementById("refreshRateInput").childNodes[3].setAttribute("required", "");
            break;

        case "motherboard":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");

            document.getElementById("formFactorInput").className = "col-sm-4 m-3";
            document.getElementById("socketInput").className = "col-sm-4 m-3";
            document.getElementById("createMotherboard").className = "btn btn-success";
            document.getElementById("formFactorInput").childNodes[3].setAttribute("required", "");
            document.getElementById("socketInput").childNodes[3].setAttribute("required", "");
            break;

        case "storage":
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");

            document.getElementById("storageTypeInput").className = "col-sm-4 m-3";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3";
            document.getElementById("createStorage").className = "btn btn-success";
            document.getElementById("storageTypeInput").childNodes[3].setAttribute("required", "");
            document.getElementById("storageSizeInput").childNodes[3].setAttribute("required", "");
            break;

        default:
            document.getElementById("screenSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("ramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("vramInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("cudaCoreInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("formFactorInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("coresInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("clockSpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("socketInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memoryTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("memorySpeedInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("refreshRateInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageTypeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("storageSizeInput").className = "col-sm-4 m-3 d-none";
            document.getElementById("createCase").className = "btn btn-success d-none";
            document.getElementById("createCPU").className = "btn btn-success d-none";
            document.getElementById("createGraphicsCard").className = "btn btn-success d-none";
            document.getElementById("createLaptop").className = "btn btn-success d-none";
            document.getElementById("createMemory").className = "btn btn-success d-none";
            document.getElementById("createMonitor").className = "btn btn-success d-none";
            document.getElementById("createMotherboard").className = "btn btn-success d-none";
            document.getElementById("createStorage").className = "btn btn-success d-none";
            console.log("WARNING: chosen type not recognised.")

            document.getElementById("screenSizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("ramInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageInput").childNodes[3].removeAttribute("required");
            document.getElementById("vramInput").childNodes[3].removeAttribute("required");
            document.getElementById("cudaCoreInput").childNodes[3].removeAttribute("required");
            document.getElementById("formFactorInput").childNodes[3].removeAttribute("required");
            document.getElementById("coresInput").childNodes[3].removeAttribute("required");
            document.getElementById("clockSpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("socketInput").childNodes[3].removeAttribute("required");
            document.getElementById("memoryTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySizeInput").childNodes[3].removeAttribute("required");
            document.getElementById("memorySpeedInput").childNodes[3].removeAttribute("required");
            document.getElementById("refreshRateInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageTypeInput").childNodes[3].removeAttribute("required");
            document.getElementById("storageSizeInput").childNodes[3].removeAttribute("required");
            break;
    }
}

function ToggleLightMode() {
    localStorage.setItem("light-mode", "enabled");
    localStorage.setItem("dark-mode", "disabled");
    document.body.className = "";
    if (document.getElementById("navigation") != null) { document.getElementById("navigation").classList.remove("dark-mode") }
}

function ToggleDarkMode() {
    localStorage.setItem("dark-mode", "enabled");
    localStorage.setItem("light-mode", "disabled");
    document.body.className = "dark-mode";
    if (document.getElementById("navigation") != null) { document.getElementById("navigation").classList.add("dark-mode") }
}

function CheckDisplayMode(pageTitle) {

    if (pageTitle === "Settings" || pageTitle === "Customer Settings") {
        if (localStorage.getItem("light-mode") === "enabled") {
            document.getElementById("lightModeRadio").setAttribute("checked", "");
        }
        if (localStorage.getItem("dark-mode") === "enabled") {
            document.getElementById("darkModeRadio").setAttribute("checked", "");
        }
    }

    if (localStorage.getItem("light-mode") === "enabled") {
        document.body.className = "";
        if (document.getElementById("table") != null) {
            var test = document.getElementsByClassName("table");
            for (var element of test) {
                element.classList.remove("dark-mode");
            }
        }
        if (document.getElementById("navigation") != null) { document.getElementById("navigation").classList.remove("dark-mode") }
    }
    if (localStorage.getItem("dark-mode") === "enabled") {
        document.body.className = "dark-mode";
        if (document.getElementById("table") != null) {
            var test = document.getElementsByClassName("table");
            for (var element of test) {
                element.classList.add("dark-mode");
            }
        }
        if (document.getElementById("navigation") != null) { document.getElementById("navigation").classList.add("dark-mode") }
    }
}

function AdjustSliderValue() {
    document.getElementById("amountText").innerText = document.getElementById("amountRange").valueAsNumber;
}
