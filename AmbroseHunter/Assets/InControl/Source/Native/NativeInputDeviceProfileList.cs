namespace InControl
{
	using UnityEngine;


	public class NativeInputDeviceProfileList : ScriptableObject
	{
		public static readonly string[] Profiles = new string[]
		{
			"InControl.NativeProfile.AfterglowPrismaticXboxOneControllerMacProfile",
			"InControl.NativeProfile.AfterglowXbox360WindowsNativeProfile",
			"InControl.NativeProfile.AirFloControllerMacProfile",
			"InControl.NativeProfile.AirFloPS3WindowsNativeProfile",
			"InControl.NativeProfile.AtPlayControllerMacProfile",
			"InControl.NativeProfile.BatarangControllerMacProfile",
			"InControl.NativeProfile.BETAOPControllerMacProfile",
			"InControl.NativeProfile.BigBenControllerMacProfile",
			"InControl.NativeProfile.BrookNeoGeoConverterMacProfile",
			"InControl.NativeProfile.BrookPS2ConverterMacProfile",
			"InControl.NativeProfile.BuffaloClassicMacProfile",
			"InControl.NativeProfile.BuffaloClassicWindowsNativeProfile",
			"InControl.NativeProfile.EASportsControllerMacProfile",
			"InControl.NativeProfile.EightBitdoNES30ProBTMacNativeProfile",
			"InControl.NativeProfile.EightBitdoNES30ProUSBMacNativeProfile",
			"InControl.NativeProfile.EightBitdoNES30ProWindowsNativeProfile",
			"InControl.NativeProfile.EightBitdoSFC30MacNativeProfile",
			"InControl.NativeProfile.EightBitdoSFC30WindowsNativeProfile",
			"InControl.NativeProfile.EightBitdoSNES30MacNativeProfile",
			"InControl.NativeProfile.EightBitdoSNES30WindowsNativeProfile",
			"InControl.NativeProfile.ElecomControllerMacProfile",
			"InControl.NativeProfile.GameCubeMayflashWindowsNativeProfile",
			"InControl.NativeProfile.GameStopControllerMacProfile",
			"InControl.NativeProfile.GuitarHeroControllerMacProfile",
			"InControl.NativeProfile.HoriBlueSoloControllerMacProfile",
			"InControl.NativeProfile.HoriControllerMacProfile",
			"InControl.NativeProfile.HoriDOA4ArcadeStickMacProfile",
			"InControl.NativeProfile.HoriEX2ControllerMacProfile",
			"InControl.NativeProfile.HoriFightingCommanderMacProfile",
			"InControl.NativeProfile.HoriFightingStickEX2MacProfile",
			"InControl.NativeProfile.HoriFightingStickVXMacProfile",
			"InControl.NativeProfile.HoriFightStickMacProfile",
			"InControl.NativeProfile.HoriHoriRealArcadeProIVMacProfile",
			"InControl.NativeProfile.HoriHoriRealArcadeProVHayabusaMacProfile",
			"InControl.NativeProfile.HoriPadEXTurboControllerMacProfile",
			"InControl.NativeProfile.HoriPadUltimateMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProEXMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProEXPremiumVLXMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProEXSEMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProHayabusaMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProIVMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProVHayabusaMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProVKaiFightingStickMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProVXMacProfile",
			"InControl.NativeProfile.HoriRealArcadeProVXSAMacProfile",
			"InControl.NativeProfile.HoriXbox360GemPadExMacProfile",
			"InControl.NativeProfile.HyperkinX91MacProfile",
			"InControl.NativeProfile.InjusticeFightStickMacProfile",
			"InControl.NativeProfile.IonDrumRockerMacProfile",
			"InControl.NativeProfile.JoytekXbox360ControllerMacProfile",
			"InControl.NativeProfile.KonamiDancePadMacProfile",
			"InControl.NativeProfile.LogitechChillStreamControllerMacProfile",
			"InControl.NativeProfile.LogitechControllerMacProfile",
			"InControl.NativeProfile.LogitechDriveFXRacingWheelMacProfile",
			"InControl.NativeProfile.LogitechF310ControllerMacProfile",
			"InControl.NativeProfile.LogitechF310ModeDMacProfile",
			"InControl.NativeProfile.LogitechF310ModeDWindowsNativeProfile",
			"InControl.NativeProfile.LogitechF310ModeXWindowsNativeProfile",
			"InControl.NativeProfile.LogitechF510ControllerMacProfile",
			"InControl.NativeProfile.LogitechF510ModeDMacProfile",
			"InControl.NativeProfile.LogitechF510ModeDWindowsNativeProfile",
			"InControl.NativeProfile.LogitechF510ModeXWindowsNativeProfile",
			"InControl.NativeProfile.LogitechF710ControllerMacProfile",
			"InControl.NativeProfile.LogitechF710ModeDMacProfile",
			"InControl.NativeProfile.LogitechF710ModeDWindowsNativeProfile",
			"InControl.NativeProfile.LogitechF710ModeXWindowsNativeProfile",
			"InControl.NativeProfile.LogitechG920RacingWheelMacProfile",
			"InControl.NativeProfile.LogitechThunderpadMacProfile",
			"InControl.NativeProfile.MadCatzArcadeStickMacProfile",
			"InControl.NativeProfile.MadCatzBrawlStickMacProfile",
			"InControl.NativeProfile.MadCatzCODControllerMacProfile",
			"InControl.NativeProfile.MadCatzControllerMacProfile",
			"InControl.NativeProfile.MadCatzFightPadControllerMacProfile",
			"InControl.NativeProfile.MadCatzFightPadMacProfile",
			"InControl.NativeProfile.MadCatzFightStickTE2MacProfile",
			"InControl.NativeProfile.MadCatzFightStickTESPlusMacProfile",
			"InControl.NativeProfile.MadCatzFPSProMacProfile",
			"InControl.NativeProfile.MadCatzMC2RacingWheelMacProfile",
			"InControl.NativeProfile.MadCatzMicroConControllerMacProfile",
			"InControl.NativeProfile.MadCatzMicroControllerMacProfile",
			"InControl.NativeProfile.MadCatzMLGFightStickTEMacProfile",
			"InControl.NativeProfile.MadCatzNeoFightStickMacProfile",
			"InControl.NativeProfile.MadCatzPortableDrumMacProfile",
			"InControl.NativeProfile.MadCatzProControllerMacProfile",
			"InControl.NativeProfile.MadCatzSaitekAV8R02MacProfile",
			"InControl.NativeProfile.MadCatzSF4FightStickRound2TEMacProfile",
			"InControl.NativeProfile.MadCatzSF4FightStickSEMacProfile",
			"InControl.NativeProfile.MadCatzSF4FightStickTEMacProfile",
			"InControl.NativeProfile.MadCatzSoulCaliberFightStickMacProfile",
			"InControl.NativeProfile.MadCatzSSF4ChunLiFightStickTEMacProfile",
			"InControl.NativeProfile.MadCatzSSF4FightStickTEMacProfile",
			"InControl.NativeProfile.MatCatzControllerMacProfile",
			"InControl.NativeProfile.MayflashMagicNSMacProfile",
			"InControl.NativeProfile.MicrosoftXbox360ControllerMacProfile",
			"InControl.NativeProfile.MicrosoftXboxControllerMacProfile",
			"InControl.NativeProfile.MicrosoftXboxOneControllerMacProfile",
			"InControl.NativeProfile.MicrosoftXboxOneEliteControllerMacProfile",
			"InControl.NativeProfile.MKKlassikFightStickMacProfile",
			"InControl.NativeProfile.MLGControllerMacProfile",
			"InControl.NativeProfile.MVCTEStickMacProfile",
			"InControl.NativeProfile.NaconGC100XFControllerMacProfile",
			"InControl.NativeProfile.NintendoSwitchProMacNativeProfile",
			"InControl.NativeProfile.NintendoSwitchProWindowsNativeProfile",
			"InControl.NativeProfile.NVidiaShieldWindowsNativeProfile",
			"InControl.NativeProfile.PCTWINSHOCKWindowsNativeProfile",
			"InControl.NativeProfile.PDPAfterglowControllerMacProfile",
			"InControl.NativeProfile.PDPBattlefieldXBoxOneControllerMacProfile",
			"InControl.NativeProfile.PDPMarvelControllerMacProfile",
			"InControl.NativeProfile.PDPTitanfall2XboxOneControllerMacProfile",
			"InControl.NativeProfile.PDPTronControllerMacProfile",
			"InControl.NativeProfile.PDPVersusControllerMacProfile",
			"InControl.NativeProfile.PDPXbox360ControllerMacProfile",
			"InControl.NativeProfile.PDPXboxOneArcadeStickMacProfile",
			"InControl.NativeProfile.PDPXboxOneControllerMacProfile",
			"InControl.NativeProfile.PlayStation3MacProfile",
			"InControl.NativeProfile.PlayStation4MacProfile",
			"InControl.NativeProfile.PlayStation4WindowsNativeProfile",
			"InControl.NativeProfile.PowerAAirflowControllerMacProfile",
			"InControl.NativeProfile.POWERAFUS1ONTournamentControllerMacProfile",
			"InControl.NativeProfile.PowerAMiniControllerMacProfile",
			"InControl.NativeProfile.PowerAMiniProExControllerMacProfile",
			"InControl.NativeProfile.PowerAMiniXboxOneControllerMacProfile",
			"InControl.NativeProfile.PowerASpectraIlluminatedControllerMacProfile",
			"InControl.NativeProfile.ProEXXbox360ControllerMacProfile",
			"InControl.NativeProfile.ProEXXboxOneControllerMacProfile",
			"InControl.NativeProfile.QanbaFightStickPlusMacProfile",
			"InControl.NativeProfile.RazerAtroxArcadeStickMacProfile",
			"InControl.NativeProfile.RazerOnzaControllerMacProfile",
			"InControl.NativeProfile.RazerOnzaTEControllerMacProfile",
			"InControl.NativeProfile.RazerSabertoothEliteControllerMacProfile",
			"InControl.NativeProfile.RazerServalWindowsNativeProfile",
			"InControl.NativeProfile.RazerStrikeControllerMacProfile",
			"InControl.NativeProfile.RazerWildcatControllerMacProfile",
			"InControl.NativeProfile.RazerWolverineUltimateControllerMacProfile",
			"InControl.NativeProfile.RedOctaneControllerMacProfile",
			"InControl.NativeProfile.RockBandDrumsMacProfile",
			"InControl.NativeProfile.RockBandGuitarMacProfile",
			"InControl.NativeProfile.RockCandyControllerMacProfile",
			"InControl.NativeProfile.RockCandyPS3ControllerMacProfile",
			"InControl.NativeProfile.RockCandyXbox360ControllerMacProfile",
			"InControl.NativeProfile.RockCandyXboxOneControllerMacProfile",
			"InControl.NativeProfile.SaitekXbox360ControllerMacProfile",
			"InControl.NativeProfile.SteamWindowsNativeProfile",
			"InControl.NativeProfile.ThrustMasterFerrari430RacingWheelMacProfile",
			"InControl.NativeProfile.ThrustmasterFerrari458RacingWheelMacProfile",
			"InControl.NativeProfile.ThrustMasterFerrari458SpiderRacingWheelMacProfile",
			"InControl.NativeProfile.ThrustmasterGPXControllerMacProfile",
			"InControl.NativeProfile.TrustPredatorJoystickMacProfile",
			"InControl.NativeProfile.TSZPelicanControllerMacProfile",
			"InControl.NativeProfile.Xbox360ControllerMacProfile",
			"InControl.NativeProfile.Xbox360DriverMacProfile",
			"InControl.NativeProfile.Xbox360MortalKombatFightStickMacProfile",
			"InControl.NativeProfile.Xbox360WiredWindowsNativeProfile",
			"InControl.NativeProfile.Xbox360WirelessWindowsNativeProfile",
			"InControl.NativeProfile.XboxOneControllerMacProfile",
			"InControl.NativeProfile.XboxOneDriverMacProfile",
			"InControl.NativeProfile.XboxOneEliteWindows10AENativeProfile",
			"InControl.NativeProfile.XboxOneEliteWindowsNativeProfile",
			"InControl.NativeProfile.XboxOneSMacProfile",
			"InControl.NativeProfile.XboxOneWindows10AENativeProfile",
			"InControl.NativeProfile.XboxOneWindows10NativeProfile",
			"InControl.NativeProfile.XboxOneWindowsNativeProfile",
			"InControl.NativeProfile.XboxOneWirelessAdapterWindowsNativeProfile",
			"InControl.NativeProfile.XInputWindowsNativeProfile",
			"InControl.NativeProfile.XTR_G2_MacNativeProfile",
			"InControl.NativeProfile.XTR_G2_WindowsNativeProfile",
			"InControl.NativeProfile.XTR55_G2_MacNativeProfile",
			"InControl.NativeProfile.XTR55_G2_WindowsNativeProfile",
		};
	}
}