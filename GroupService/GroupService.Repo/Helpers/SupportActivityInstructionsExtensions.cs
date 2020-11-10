﻿using GroupService.Repo.EntityFramework.Entities;
using HelpMyStreet.Utils.Enums;
using HelpMyStreet.Utils.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace GroupService.Repo.Helpers
{
    public static class SupportActivityInstructionsExtensions
    {
        public static void SetEnumSupportActivityInstructionsExtensionsData(this EntityTypeBuilder<EnumSupportActivityInstructions> entity)
        {
            var supportActivityInstructions = Enum.GetValues(typeof(HelpMyStreet.Utils.Enums.SupportActivityInstructions)).Cast<HelpMyStreet.Utils.Enums.SupportActivityInstructions>();

            foreach (var instruction in supportActivityInstructions)
            {
                entity.HasData(new EnumSupportActivityInstructions { Id = (int)instruction, Name = instruction.ToString() });
            }
        }

        private static Instructions GetInstructions_HmsShopping()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Shopping,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Confirm what they need and agree how they will pay you back. You can find out more about secure payment methods in our [FAQs](/questions#5). If someone else has requested the help on their behalf it may be useful to give them a call too.",
                    },
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Pick up their shopping and drop it off at their door. Make sure you keep a copy of the receipt (e.g. by taking a photo) and give them the original along with their shopping."
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us and anyone else involved with the request know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch."
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsOtherPurchase()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Confirm what they need. Check if they’ll be a charge for anything, and if needed agree how they will pay you back.You can find out more about secure payment methods in our [FAQs](/questions#5). If someone else has requested the help on their behalf it may be useful to give them a call too.",
                    },
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Provide the help they need. If you do have to pay for something on their behalf, make sure you keep a copy of the receipt (e.g. by taking a photo) and give them the original along with their purchase."
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch."
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsGeneral()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Get in touch with the person who needs the help to confirm what they need. If someone else has requested the help on their behalf it may be useful to give them a call too.",
                    },
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Provide the help that’s needed.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsFriendlyChat()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FriendlyChat,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Give them a call",
                        Detail = "Be a friendly voice at the end of the phone and have a good natter.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch. If someone else has requested the help on their behalf it may be useful to give them a call to let them know how it went.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsHomework()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Homework,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Get in touch to find out how you can help.",
                    },
                    new Step()
                    {
                        Heading = "Solve the problem… hopefully!",
                        Detail = "If you’re able, give them the support they need.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due (including if you don’t know the answer!), let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsCheckIn()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_CheckIn,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Check in",
                        Detail = "Give them a call or knock on the door to find out if they’re OK. You can also see if they need anything and let them know someone’s asking after them.",
                    },
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "A check in is usually requested by someone else for a friend, neighbour or loved one. Give the person who requested the help a call to let them know how it went.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_HmsFaceCovering()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FaceCovering,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Confirm what they need and agree how they will pay you back (£2 - £3 per face covering to cover the cost of materials plus the cost of postage if required). You can find out more about secure payment methods in our [FAQs](/questions#5).",
                    },
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Make the face coverings and deliver them (or pop them in the post). If you need to claim back the cost of postage don’t forget to keep a copy of the receipt.",
                    },
                    new Step()
                    {
                        Heading = "Let them know they’re on the way",
                        Detail = "Drop the recipient a note to let them know they’re on the way.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_FtlosFaceCovering()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.FTLOS_FaceCovering,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact the requester",
                        Detail = "Confirm what they need. Let them know that they can make a donation [here](https://www.gofundme.com/f/for-the-love-of-scrubs-face-coverings?utm_source=widget&utm_medium=referral&utm_campaign=p_cp+share-sheet) (suggested £3 - £4 per face covering). If you need to post the face coverings let them know if you’ll need them to cover the cost of postage on top of the donation and agree how they will pay you back. You can find out more about secure payment methods in our [FAQs](/questions#5).",
                    },
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Make the face coverings and deliver them (or pop them in the post). If you need to claim back the cost of postage don’t forget to keep a copy of the receipt. If you need more materials email requestmaterials.ftlos@outlook.com.",
                    },
                    new Step()
                    {
                        Heading = "Let them know they’re on the way",
                        Detail = "Drop the recipient a note to let them know they’re on the way and share a link to [our fundraising page](https://www.gofundme.com/f/for-the-love-of-scrubs-face-coverings?utm_source=widget&utm_medium=referral&utm_campaign=p_cp+share-sheet).",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKLincoln_V4V()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLincoln_V4V,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact us (Age UK Lincoln & South Lincolnshire)",
                        Detail = "Please contact volunteering@ageuklsl.org.uk to arrange collection of a pre-made wellbeing package from one of our sites. We’ll also give you all the details you need for the delivery.",
                    },
                    new Step()
                    {
                        Heading = "Deliver the package",
                        Detail = "Use the details provided to deliver the package. It would be great if you could also stop for a quick chat to say hello and see how they’re getting on.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. If you have any concerns about the person you visited let us know immediately by emailing volunteering@ageuklsl.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKWirral_Shopping()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Shopping,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Go shopping",
                        Detail = "Pick up their shopping, you will find their shopping list and any specific instructions in “My Accepted Requests”. You’ll need to pay for the shopping on your own card before claiming the money back.",
                    },
                    new Step()
                    {
                        Heading = "Send us a copy of the receipt",
                        Detail = "Write the name of the client on the receipt and email us a photograph to mailto:emergencyvols@ageukwirral.org.uk. We’ll transfer the money as soon as possible via bank transfer.",
                    },
                    new Step()
                    {
                        Heading = "Drop off the shopping",
                        Detail = "Drop off the shopping along with the original copy of the receipt. You’ll find their details in “My Accepted Requests”.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. If you have any concerns about the person you visited let us know immediately by emailing mailto:H&Cadminteam@ageukwirral.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKWirral_General()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_General,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Provide help",
                        Detail = "Provide the help that’s needed.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. You’ll still be able to find their contact details in “My Complete Requests” in case you need to get back in touch.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKWirral_Prescriptions()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Prescriptions,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Collect the prescription",
                        Detail = "Collect the prescription from the pharmacy, you will find details of the pharmacy in “My Accepted Requests”. If the prescription needs paying for, you’ll need to pay for it on your own card before claiming the money back.",
                    },
                    new Step()
                    {
                        Heading = "Send us a copy of the receipt (if you paid)",
                        Detail = "If you paid for the prescription, write the name of the client on the receipt and email us a photograph to mailto:emergencyvols@ageukwirral.org.uk. We’ll transfer the money as soon as possible via bank transfer.",
                    },
                    new Step()
                    {
                        Heading = "Drop off the medication",
                        Detail = "Drop off the medication (along with the original copy of the receipt if you paid for it). You’ll find their details in “My Accepted Requests”",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests” - this will let us (and anyone else involved with the request) know it's been completed. If you have any concerns about the person you visited let us know immediately by emailing mailto:H&Cadminteam@ageukwirral.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKLSL_Shopping()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Shopping,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact us (Age UK Lincoln & South Lincolnshire)",
                        Detail = "Please contact mailto:volunteering@ageuklsl.org.uk to receive further information about this request. We’ll also give you all the details you need for the delivering the items.",
                    },
                    new Step()
                    {
                        Heading = "Purchase the shopping items",
                        Detail = "Use the details given to you to carry out the request. It would be great if you could also stop for a quick chat to say hello and see how they’re getting on.",
                    },  
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests”. If you have any concerns about the person you visited let us know immediately by emailing mailto:volunteering@ageuklsl.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKLSL_Prescriptions()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Prescriptions,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact us (Age UK Lincoln & South Lincolnshire)",
                        Detail = "Please contact mailto:volunteering@ageuklsl.org.uk to receive further information about this request. We’ll also give you all the details you need for the prescription collection and delivering the medication.",
                    },
                    new Step()
                    {
                        Heading = "Collecting the prescription",
                        Detail = "Use the details given to you to carry out the request. It would be great if you could also stop for a quick chat to say hello and see how they’re getting on.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests”. If you have any concerns about the person you visited let us know immediately by emailing mailto:volunteering@ageuklsl.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        private static Instructions GetInstructions_AgeUKLSL_General()
        {
            return new Instructions()
            {
                SupportActivityInstructions = HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_General,
                Intro = null,
                Steps = new System.Collections.Generic.List<Step>()
                {
                    new Step()
                    {
                        Heading = "Contact us (Age UK Lincoln & South Lincolnshire)",
                        Detail = "Please contact mailto:volunteering@ageuklsl.org.uk to receive further information about this request.",
                    },
                    new Step()
                    {
                        Heading = "Provide the help that is needed",
                        Detail = "Use the details given to you to carry out the request. It would be great if you could also stop for a quick chat to say hello and see how they’re getting on.",
                    },
                    new Step()
                    {
                        Heading = "Mark the request as complete",
                        Detail = "Once you’ve done, mark the request as complete in “My Accepted Requests”. If you have any concerns about the person you visited let us know immediately by emailing mailto:volunteering@ageuklsl.org.uk.",
                    }
                },
                Close = "If for any reason you can’t complete the request before it’s due, let us know by updating the accepted request and clicking “Can’t Do”."
            };
        }

        public static void PopulateSupportActivityInstructions(this EntityTypeBuilder<EntityFramework.Entities.SupportActivityInstructions> entity)
        {
            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Shopping,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsShopping())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsOtherPurchase())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsGeneral())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FriendlyChat,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsFriendlyChat())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Homework,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsHomework())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_CheckIn,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsCheckIn())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FaceCovering,
                Instructions = JsonConvert.SerializeObject(GetInstructions_HmsFaceCovering())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.FTLOS_FaceCovering,
                Instructions = JsonConvert.SerializeObject(GetInstructions_FtlosFaceCovering())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLincoln_V4V,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKLincoln_V4V())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Shopping,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKWirral_Shopping())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Prescriptions,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKWirral_Prescriptions())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_General,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKWirral_General())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Shopping,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKLSL_Shopping())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Prescriptions,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKLSL_Prescriptions())
            });

            entity.HasData(new EntityFramework.Entities.SupportActivityInstructions
            {
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_General,
                Instructions = JsonConvert.SerializeObject(GetInstructions_AgeUKLSL_General())
            });
        }


        private static void PopulateGroupShoppingInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Shopping,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Shopping
            });
            
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Shopping,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Shopping
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Shopping,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Shopping
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Shopping,
                GroupId = (int)Groups.AgeUKWirral,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Shopping
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Shopping,
                GroupId = (int)Groups.AgeUKLSL,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Shopping
            });
        }

        private static void PopulateGroupPrescriptionInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CollectingPrescriptions,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CollectingPrescriptions,
                GroupId = (int)Groups.AgeUKLSL,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_Prescriptions
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CollectingPrescriptions,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CollectingPrescriptions,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CollectingPrescriptions,
                GroupId = (int)Groups.AgeUKWirral,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_Prescriptions
            });
        }

        private static void PopulateGroupErrandsInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Errands,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Errands,
                GroupId = (int)Groups.AgeUKLSL,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_General
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Errands,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Errands,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });
        }

        private static void PopulateGroupDogWalkingInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.DogWalking,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General
            });
        }

        private static void PopulateGroupPreparedMealsInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.MealPreparation,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General
            });
            
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.MealPreparation,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.MealPreparation,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_General
            });
        }

        private static void PopulateGroupFriendlyChatInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.PhoneCalls_Friendly,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FriendlyChat
            });
            
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.PhoneCalls_Friendly,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FriendlyChat
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.PhoneCalls_Friendly,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FriendlyChat
            });
        }

        private static void PopulateGroupHomeworkInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.HomeworkSupport,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Homework
            });
            
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.HomeworkSupport,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_Homework
            });
        }

        private static void PopulateGroupCheckInInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CheckingIn,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_CheckIn
            });            

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CheckingIn,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_CheckIn
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.CheckingIn,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_CheckIn
            });
        }

        private static void PopulateGroupOtherInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Other,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Other,
                GroupId = (int)Groups.AgeUKLSL,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLSL_General
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Other,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.Other,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_OtherPurchase
            });
        }

        private static void PopulateGroupFaceCoveringInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.FaceMask,
                GroupId = (int)Groups.Generic,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FaceCovering
            });
            
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.FaceMask,
                GroupId = (int)Groups.FTLOS,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.FTLOS_FaceCovering
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.FaceMask,
                GroupId = (int)Groups.Tankersley,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FaceCovering
            });

            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.FaceMask,
                GroupId = (int)Groups.Ruddington,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.HMS_FaceCovering
            });
        }

        private static void PopulateGroupWellbeingPackageInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.WellbeingPackage,
                GroupId = (int)Groups.AgeUKLSL,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKLincoln_V4V
            });
        }

        private static void PopulateGroupColdWeatherArmyInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            entity.HasData(new GroupSupportActivityInstructions()
            {
                SupportActivityId = (int)SupportActivities.ColdWeatherArmy,
                GroupId = (int)Groups.AgeUKWirral,
                SupportActivityInstructionsId = (short)HelpMyStreet.Utils.Enums.SupportActivityInstructions.AgeUKWirral_General
            });
        }

        public static void PopulateGroupSupportActivityInstructions(this EntityTypeBuilder<GroupSupportActivityInstructions> entity)
        {
            PopulateGroupShoppingInstructions(entity);
            PopulateGroupPrescriptionInstructions(entity);
            PopulateGroupErrandsInstructions(entity);
            PopulateGroupDogWalkingInstructions(entity);
            PopulateGroupPreparedMealsInstructions(entity);
            PopulateGroupFriendlyChatInstructions(entity);
            PopulateGroupHomeworkInstructions(entity);
            PopulateGroupCheckInInstructions(entity);
            PopulateGroupOtherInstructions(entity);
            PopulateGroupFaceCoveringInstructions(entity);
            PopulateGroupWellbeingPackageInstructions(entity);
            PopulateGroupColdWeatherArmyInstructions(entity);
        }
    }
}
