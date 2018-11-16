﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iOSSpecialFeatures.MobileAppService.Data;

namespace iOSSpecialFeatures.MobileAppService.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.ChangeDataHash", b =>
                {
                    b.Property<int>("ChangeDataHashID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("change_data_hash_id");

                    b.Property<int>("ContactEmailAddressesHash")
                        .HasColumnName("contact_email_addresses_hash");

                    b.Property<int>("ContactPhoneNumbersHash")
                        .HasColumnName("contact_phone_numbers_hash");

                    b.Property<int>("ContactsHash")
                        .HasColumnName("contacts_hash");

                    b.HasKey("ChangeDataHashID");

                    b.ToTable("change_data_hash");
                });

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(30);

                    b.Property<bool>("IsFriend")
                        .HasColumnName("is_friend");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(30);

                    b.Property<string>("MiddleName")
                        .HasColumnName("middle_name")
                        .HasMaxLength(30);

                    b.Property<string>("NickName")
                        .HasColumnName("nick_name")
                        .HasMaxLength(30);

                    b.HasKey("ContactID");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.ContactEmail", b =>
                {
                    b.Property<Guid>("ContactEmailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contact_email_id");

                    b.Property<Guid>("ContactID")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnName("email_address")
                        .HasMaxLength(255);

                    b.Property<string>("EmailType")
                        .HasColumnName("email_type")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnName("last_modified_date");

                    b.HasKey("ContactEmailID");

                    b.HasIndex("ContactID");

                    b.ToTable("contact_email");
                });

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.ContactPhone", b =>
                {
                    b.Property<Guid>("ContactPhoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("contact_phone_id");

                    b.Property<Guid>("ContactID")
                        .HasColumnName("contact_id");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnName("last_modified_date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnName("phone_number")
                        .HasMaxLength(15);

                    b.Property<string>("PhoneType")
                        .HasColumnName("phone_type")
                        .HasMaxLength(20);

                    b.HasKey("ContactPhoneID");

                    b.HasIndex("ContactID");

                    b.ToTable("contact_phone");
                });

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.ContactEmail", b =>
                {
                    b.HasOne("iOSSpecialFeatures.MobileAppService.Data.Models.Contact", "Contact")
                        .WithMany("EmailAddresses")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iOSSpecialFeatures.MobileAppService.Data.Models.ContactPhone", b =>
                {
                    b.HasOne("iOSSpecialFeatures.MobileAppService.Data.Models.Contact", "Contact")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ContactID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
