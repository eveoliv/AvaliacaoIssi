﻿// <auto-generated />
using System;
using Avaliacoes.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Avaliacoes.Migrations
{
    [DbContext(typeof(AvaliacaoDbContext))]
    partial class AvaliacaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Avaliacoes.Domain.Avaliacao", b =>
                {
                    b.Property<int>("AvaliacaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AvaliacaoId"));

                    b.Property<int>("Acoes")
                        .HasColumnType("int");

                    b.Property<string>("Avaliador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Bondes")
                        .HasColumnType("int");

                    b.Property<int>("Contencao")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFull")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataMeio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataPP")
                        .HasColumnType("datetime2");

                    b.Property<int>("Dedicacao")
                        .HasColumnType("int");

                    b.Property<int>("DivisaoId")
                        .HasColumnType("int");

                    b.Property<int>("Estudos")
                        .HasColumnType("int");

                    b.Property<bool>("Exibir")
                        .HasColumnType("bit");

                    b.Property<int>("Financeiro")
                        .HasColumnType("int");

                    b.Property<int>("Frequencia")
                        .HasColumnType("int");

                    b.Property<string>("Grau")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Nota")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Operacional")
                        .HasColumnType("int");

                    b.Property<int>("Pubs")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("AvaliacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Divisao", b =>
                {
                    b.Property<int>("DivisaoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DivisaoId"));

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DivisaoId");

                    b.ToTable("Divisao");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<int>("Admin")
                        .HasColumnType("int");

                    b.Property<int>("DivisaoId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("DivisaoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Avaliacao", b =>
                {
                    b.HasOne("Avaliacoes.Domain.Usuario", "Usuario")
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Usuario", b =>
                {
                    b.HasOne("Avaliacoes.Domain.Divisao", "Divisao")
                        .WithMany("Usuarios")
                        .HasForeignKey("DivisaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Divisao");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Divisao", b =>
                {
                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("Avaliacoes.Domain.Usuario", b =>
                {
                    b.Navigation("Avaliacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
