﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OmeLi.Data;

#nullable disable

namespace OmeLi.Migrations
{
    [DbContext(typeof(BDContext))]
    partial class BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OmeLi.Models.ContatoPessoa", b =>
                {
                    b.Property<int>("ContatoPessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContatoPessoaId"), 1L, 1);

                    b.Property<int>("DddTelefone")
                        .HasColumnType("int");

                    b.Property<string>("EnderecoEmail")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NumeroTelefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoTelefoneId")
                        .HasColumnType("int");

                    b.HasKey("ContatoPessoaId");

                    b.HasIndex("PessoaId");

                    b.HasIndex("TipoTelefoneId");

                    b.ToTable("ContatosPessoas");
                });

            modelBuilder.Entity("OmeLi.Models.Editora", b =>
                {
                    b.Property<int>("EditoraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EditoraId"), 1L, 1);

                    b.Property<string>("CnpjEditora")
                        .IsRequired()
                        .HasColumnType("char(14)");

                    b.Property<string>("DescEditora")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NomeEditora")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("EditoraId");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("OmeLi.Models.EnderecoPessoa", b =>
                {
                    b.Property<int>("EnderecoPessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnderecoPessoaId"), 1L, 1);

                    b.Property<string>("BairroEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.Property<string>("CepEndereo")
                        .IsRequired()
                        .HasColumnType("varchar(13)");

                    b.Property<string>("CidadeEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ComplementoEndereco")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("EnderecoForn")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("NumeroEndereco")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<string>("UfEndereco")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.HasKey("EnderecoPessoaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("EnderecosPessoas");
                });

            modelBuilder.Entity("OmeLi.Models.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstoqueId"), 1L, 1);

                    b.Property<string>("DescEstoque")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("NomeEstoque")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<int>("QtdLivroEstoque")
                        .HasColumnType("int");

                    b.HasKey("EstoqueId");

                    b.ToTable("Estoques");

                    b.HasData(
                        new
                        {
                            EstoqueId = 1,
                            DescEstoque = "Estoque de livros padrão",
                            NomeEstoque = "Estoque de livros",
                            QtdLivroEstoque = 0
                        });
                });

            modelBuilder.Entity("OmeLi.Models.Livro", b =>
                {
                    b.Property<int>("LivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroId"), 1L, 1);

                    b.Property<string>("DescLivro")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<int>("EditoraId")
                        .HasColumnType("int");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<string>("NomeLivro")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<int>("QtdeLivro")
                        .HasColumnType("int");

                    b.Property<int>("StatusLivroId")
                        .HasColumnType("int");

                    b.HasKey("LivroId");

                    b.HasIndex("EditoraId");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("StatusLivroId");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("OmeLi.Models.LivroPessoa", b =>
                {
                    b.Property<int>("LivroPessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LivroPessoaId"), 1L, 1);

                    b.Property<DateTime>("DataDevolucao")
                        .HasColumnType("datetime2");

                    b.Property<int>("LivroId")
                        .HasColumnType("int");

                    b.Property<int>("PessoaId")
                        .HasColumnType("int");

                    b.Property<int>("QtdeEmprestada")
                        .HasColumnType("int");

                    b.Property<int>("StatusAssociacao")
                        .HasColumnType("int");

                    b.HasKey("LivroPessoaId");

                    b.HasIndex("LivroId");

                    b.HasIndex("PessoaId");

                    b.ToTable("LivrosPessoas");
                });

            modelBuilder.Entity("OmeLi.Models.Pessoa", b =>
                {
                    b.Property<int>("PessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PessoaId"), 1L, 1);

                    b.Property<string>("CpfPessoa")
                        .IsRequired()
                        .HasColumnType("char(11)");

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<string>("SobrenomePessoa")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.Property<int>("TipoPessoaId")
                        .HasColumnType("int");

                    b.HasKey("PessoaId");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("OmeLi.Models.StatusLivro", b =>
                {
                    b.Property<int>("StatusLivroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusLivroId"), 1L, 1);

                    b.Property<string>("DescStatusLivroId")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("StatusLivroId");

                    b.ToTable("StatusLivros");

                    b.HasData(
                        new
                        {
                            StatusLivroId = 1,
                            DescStatusLivroId = "Default"
                        },
                        new
                        {
                            StatusLivroId = 2,
                            DescStatusLivroId = "Ativo"
                        },
                        new
                        {
                            StatusLivroId = 3,
                            DescStatusLivroId = "Indisponível"
                        });
                });

            modelBuilder.Entity("OmeLi.Models.TipoPessoa", b =>
                {
                    b.Property<int>("TipoPessoaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoPessoaId"), 1L, 1);

                    b.Property<string>("DescTipoPessoa")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("TipoPessoaId");

                    b.ToTable("TiposPessoas");

                    b.HasData(
                        new
                        {
                            TipoPessoaId = 1,
                            DescTipoPessoa = "Default"
                        },
                        new
                        {
                            TipoPessoaId = 2,
                            DescTipoPessoa = "Author"
                        },
                        new
                        {
                            TipoPessoaId = 3,
                            DescTipoPessoa = "Cliente"
                        });
                });

            modelBuilder.Entity("OmeLi.Models.TipoTelefone", b =>
                {
                    b.Property<int>("TipoTelefoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TipoTelefoneId"), 1L, 1);

                    b.Property<string>("DescTipoTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoTelefoneId");

                    b.ToTable("TiposTelefones");

                    b.HasData(
                        new
                        {
                            TipoTelefoneId = 1,
                            DescTipoTelefone = "Celular"
                        },
                        new
                        {
                            TipoTelefoneId = 2,
                            DescTipoTelefone = "Residencial"
                        },
                        new
                        {
                            TipoTelefoneId = 3,
                            DescTipoTelefone = "Comercial"
                        },
                        new
                        {
                            TipoTelefoneId = 4,
                            DescTipoTelefone = "Recado"
                        });
                });

            modelBuilder.Entity("OmeLi.Models.ContatoPessoa", b =>
                {
                    b.HasOne("OmeLi.Models.Pessoa", "Pessoa")
                        .WithMany("ContatosPessoas")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OmeLi.Models.TipoTelefone", "TipoTelefone")
                        .WithMany("ContatosFornecedores")
                        .HasForeignKey("TipoTelefoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");

                    b.Navigation("TipoTelefone");
                });

            modelBuilder.Entity("OmeLi.Models.EnderecoPessoa", b =>
                {
                    b.HasOne("OmeLi.Models.Pessoa", "Pessoa")
                        .WithMany("EnderecoPessoa")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("OmeLi.Models.Livro", b =>
                {
                    b.HasOne("OmeLi.Models.Editora", "Editora")
                        .WithMany("Livros")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OmeLi.Models.Estoque", "Estoque")
                        .WithMany("LivrosEstoque")
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OmeLi.Models.StatusLivro", "StatusLivro")
                        .WithMany("Livros")
                        .HasForeignKey("StatusLivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editora");

                    b.Navigation("Estoque");

                    b.Navigation("StatusLivro");
                });

            modelBuilder.Entity("OmeLi.Models.LivroPessoa", b =>
                {
                    b.HasOne("OmeLi.Models.Livro", "Livro")
                        .WithMany("LivrosPessoas")
                        .HasForeignKey("LivroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OmeLi.Models.Pessoa", "Pessoa")
                        .WithMany("PessoasLivros")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Livro");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("OmeLi.Models.Pessoa", b =>
                {
                    b.HasOne("OmeLi.Models.TipoPessoa", "TipoPessoa")
                        .WithMany("Pessoas")
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoPessoa");
                });

            modelBuilder.Entity("OmeLi.Models.Editora", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("OmeLi.Models.Estoque", b =>
                {
                    b.Navigation("LivrosEstoque");
                });

            modelBuilder.Entity("OmeLi.Models.Livro", b =>
                {
                    b.Navigation("LivrosPessoas");
                });

            modelBuilder.Entity("OmeLi.Models.Pessoa", b =>
                {
                    b.Navigation("ContatosPessoas");

                    b.Navigation("EnderecoPessoa");

                    b.Navigation("PessoasLivros");
                });

            modelBuilder.Entity("OmeLi.Models.StatusLivro", b =>
                {
                    b.Navigation("Livros");
                });

            modelBuilder.Entity("OmeLi.Models.TipoPessoa", b =>
                {
                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("OmeLi.Models.TipoTelefone", b =>
                {
                    b.Navigation("ContatosFornecedores");
                });
#pragma warning restore 612, 618
        }
    }
}
